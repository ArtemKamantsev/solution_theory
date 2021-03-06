import numpy as np

from utils import eps
from solvers.base_randomized_solver import BaseRandomizedSolver


class MinMaxRandomizedSolver(BaseRandomizedSolver):
    def __init__(self, accuracy=2):
        super().__init__(accuracy)

    @staticmethod
    def __get_wedge_intersection_indexes(convex_hull_points, point_dimension):
        """
        Finds indexes of convex hull points with minimal value by point_dimension axis
        :param convex_hull_points: list<int>
        :param point_dimension: int
        :return: list<int>
        """
        convex_hull_axis_values = convex_hull_points[:, point_dimension]
        min_value = convex_hull_axis_values.min()
        indexes = np.flatnonzero(convex_hull_axis_values == min_value)

        return indexes

    @staticmethod
    def __get_mean_line_intersection(convex_hull_points):
        """
        Finds pair of indexes of convex hull points who's section intersect first quarter bisector and this intersection
        has minimal loss.
        :param convex_hull_points: list<int>
        :return: list<int>
        """
        if len(convex_hull_points) == 0:
            return [], None, None

        intersection_indexes = []
        intersection_k = None
        intersection_loss = None

        def is_on_mean_line(point):
            return abs(point[0] - point[1]) < eps

        for idx in range(0, len(convex_hull_points)):
            prev_point = convex_hull_points[idx - 1]
            total_point = convex_hull_points[idx]

            if is_on_mean_line(total_point) and (intersection_loss is None or total_point[0] < intersection_loss + eps):
                intersection_indexes = [idx]
                intersection_k = None
                intersection_loss = total_point[0]

            nominator = total_point[1] - total_point[0]
            denominator = prev_point[0] - total_point[0] - prev_point[1] + total_point[1]
            if abs(denominator) > eps:
                k = nominator / denominator
                if 0 < k < 1:
                    total_loss = prev_point[0] * k + total_point[0] * (1 - k)
                    if intersection_loss is None or total_loss < intersection_loss - eps:
                        intersection_indexes = [idx - 1, idx]
                        intersection_k = k
                        intersection_loss = total_loss

        if len(intersection_indexes) == 1:  # this case should be handled by other flows
            intersection_indexes = []
            intersection_loss = intersection_k = None

        return intersection_indexes, intersection_k, intersection_loss

    def _solve_randomized(self, matrix, convex_hull_indexes, **kwargs):
        """
        Returns randomzied solution found by min-max criteria
        :param matrix: loss matrix
        :param convex_hull_indexes: matrix rows indices that form convex hull (from base class)
        :param kwargs:
        :return: tuple(
            result_indexes: list<int> - indices of points lying on the optimal wedge if any, empty array otherwise
            result_loss: float -  minimal possible loss
            result_k: None or float - if optimal point lying between not randomized solution,
                        you can calculate it as follow:
                        (x * p1.x + (1 - x) * p2.x, x * p1.y + (1 - x) * p2.y)
                        where p1 and p2 are first and second points from result_intersection_indexes
            result_intersection_indexes: list<int> - contains indexes of points between which the optimal point lies.
                                                    Contains 2 elements if there is such point (in this case k is not None)
                                                    or no elements at all is there is no such point.
        )
        """
        convex_hull_points = matrix[convex_hull_indexes]

        convex_hull_top_points_indexes = np.flatnonzero(convex_hull_points[:, 0] <= convex_hull_points[:, 1])
        top_matrix_indexes, top_loss = None, None
        if len(convex_hull_top_points_indexes) > 0:
            convex_hull_top_points = convex_hull_points[convex_hull_top_points_indexes]
            intersection_top_indexes = self.__get_wedge_intersection_indexes(convex_hull_top_points, point_dimension=1)
            if len(intersection_top_indexes) > 0:
                intersection_convex_hull_indexes = convex_hull_top_points_indexes[intersection_top_indexes]
                top_matrix_indexes = convex_hull_indexes[intersection_convex_hull_indexes]
                top_loss = round(matrix[top_matrix_indexes[0]][1], self._accuracy)

        convex_hull_bottom_points_indexes = np.flatnonzero(convex_hull_points[:, 0] > convex_hull_points[:, 1])
        bottom_matrix_indexes, bottom_loss = None, None
        if len(convex_hull_bottom_points_indexes) > 0:
            convex_hull_bottom_points = convex_hull_points[convex_hull_bottom_points_indexes]
            intersection_bottom_indexes = self.__get_wedge_intersection_indexes(convex_hull_bottom_points,
                                                                                point_dimension=0)
            if len(intersection_bottom_indexes) > 0:
                intersection_convex_hull_indexes = convex_hull_bottom_points_indexes[intersection_bottom_indexes]
                bottom_matrix_indexes = convex_hull_indexes[intersection_convex_hull_indexes]
                bottom_loss = round(matrix[bottom_matrix_indexes[0]][0], self._accuracy)

        mean_line_intersection_indexes, mean_line_k, mean_line_loss = self.__get_mean_line_intersection(
            convex_hull_points
        )
        if mean_line_loss is not None:
            mean_line_loss = round(mean_line_loss, self._accuracy)
        if mean_line_k is not None:
            mean_line_k = round(mean_line_k, self._accuracy)
        mean_line_matrix_indexes = None
        if len(mean_line_intersection_indexes) > 0:
            mean_line_matrix_indexes = convex_hull_indexes[mean_line_intersection_indexes]

        result_indexes = []
        result_loss = None
        intersection_ratio = None
        result_intersection_indexes = []
        if top_loss is not None:
            result_indexes.extend(top_matrix_indexes.tolist())
            result_loss = top_loss

        if bottom_loss is not None and (result_loss is not None and abs(result_loss - bottom_loss) < eps):
            result_indexes.extend(bottom_matrix_indexes.tolist())
        elif bottom_loss is not None and (result_loss is None or result_loss - bottom_loss > eps):
            result_indexes = bottom_matrix_indexes.tolist()
            result_loss = bottom_loss

        if mean_line_loss is not None and result_loss is not None and abs(mean_line_loss - result_loss) < eps:
            result_intersection_indexes = mean_line_matrix_indexes.tolist()
            intersection_ratio = mean_line_k
        elif mean_line_loss is not None and (result_loss is None or result_loss - mean_line_loss > eps):
            result_indexes = []
            result_intersection_indexes = mean_line_matrix_indexes.tolist()
            intersection_ratio = mean_line_k
            result_loss = mean_line_loss

        return {
            'loss': float(result_loss),
            'indexes_optimal': result_indexes,
            'indexes_intersection': result_intersection_indexes,
            'intersection_ratio': intersection_ratio,
        }


if __name__ == '__main__':
    top_single_point = np.array([[1, 2], [2, 3], [3, 5]])
    top_multiple = np.array([[1, 3], [2, 3], [3, 5]])

    bottom_single_point = np.array([[2, 1], [3, 2], [4, 0]])
    bottom_multiple = np.array([[3, 1], [3, 2], [4, 0]])

    mean_line1 = np.array(np.array([[1, 3], [2, 2], [3, 1]]))
    mean_line2 = np.array(np.array([[1, 3], [1.5, 2], [3, 1]]))
    mean_line3 = np.array(np.array([[1, 3], [2, 2], [3, 1], [4, 4]]))
    mean_line4 = np.array(np.array([[1, 3], [1.5, 2], [3, 1], [4, 5]]))

    combined1 = np.array([[1, 3], [2, 3], [3, 3]])
    combined2 = np.array([[1, 3], [2, 3], [3.5, 3]])
    combined3 = np.array([[3, 1], [3, 2], [3, 3]])
    combined4 = np.array([[3, 1], [3, 2], [3, 4]])

    solver = MinMaxRandomizedSolver()
    solver.take_input_win_matrix_ = False
    print(solver.solve(top_single_point))
    print(solver.solve(top_multiple))
    print(solver.solve(mean_line1))
    print(solver.solve(mean_line2))
    # todo refactor for new output format
    # print(solver.solve(top_single_point) == ([0], 2, None, []))
    # print(solver.solve(top_multiple) == ([0, 1], 3, None, []))
    # print(solver.solve(bottom_single_point) == ([0], 2, None, []))
    # print(solver.solve(bottom_multiple) == ([1, 0], 3, None, []))
    # print(solver.solve(mean_line1) == ([1], 2, None, []))
    # print(solver.solve(mean_line2) == ([], 1.8, 0.8, [1, 2]))
    # print(solver.solve(mean_line3) == ([1], 2, None, []))
    # print(solver.solve(mean_line4) == ([], 1.8, 0.8, [1, 2]))
    # print(solver.solve(combined1) == ([0, 1, 2], 3, None, []))
    # print(solver.solve(combined2) == ([0, 1], 3.0, 0.8, [2, 0]))
    # print(solver.solve(combined3) == ([2, 0, 1], 3, None, []))
    # print(solver.solve(combined4) == ([0, 1], 3, 0.67, [2, 0]))
