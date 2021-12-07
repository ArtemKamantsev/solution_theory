import numpy as np

from Jarvis import eps
from solvers.base_randomized_solver import BaseRandomizedSolver


class NeymanPirsRandomizedSolver(BaseRandomizedSolver):
    def __init__(self, accuracy=2):
        super().__init__(accuracy)

        # it is assumed first state to be controlled
        self.controlled_state_idx = 0
        self.uncontrolled_state_idx = 1

    def __get_best_loss_point_idx(self, convex_hull_points_allowed):
        if len(convex_hull_points_allowed) == 0:
            return []

        losses = convex_hull_points_allowed[:, self.uncontrolled_state_idx]
        min_loss = losses.min()
        indexes = np.flatnonzero(losses == min_loss)

        return indexes

    def __get_intersection_points_indexes(self, convex_hull_points, value):
        if len(convex_hull_points) < 2:
            return []
        result = []
        for idx in range(len(convex_hull_points)):
            prev_point = convex_hull_points[idx - 1]
            total_point = convex_hull_points[idx]
            if prev_point[self.controlled_state_idx] < value < total_point[self.controlled_state_idx] \
                    or prev_point[self.controlled_state_idx] > value > total_point[self.controlled_state_idx]:
                result.append((idx - 1, idx))

        return result

    def __get_best_intersection_loss(self, convex_hull_points, value):
        intersection_point_indexes = self.__get_intersection_points_indexes(convex_hull_points, value)
        p1_idx, p2_idx, best_k, best_loss = None, None, None, None
        for idx1, idx2 in intersection_point_indexes:
            p1 = convex_hull_points[idx1]
            p2 = convex_hull_points[idx2]

            nominator = value - p2[0]
            denominator = p1[0] - p2[0]
            if abs(denominator) > eps:
                k = nominator / denominator
                loss = p1[1] * k + p2[1] * (1 - k)
                if best_loss is None or best_loss - loss > eps:
                    p1_idx, p2_idx = idx1, idx2
                    best_k = k
                    best_loss = loss

        return p1_idx, p2_idx, best_k, best_loss

    def _solve_randomized(self, matrix, convex_hull_indexes, **kwargs):
        convex_hull_points = matrix[convex_hull_indexes]
        value = kwargs['value']

        convex_hull_indexes_allowed = np.flatnonzero(convex_hull_points[:, self.controlled_state_idx] <= value)
        convex_hull_points_allowed = convex_hull_points[convex_hull_indexes_allowed]

        result_indexes = []
        result_loss = None
        result_k = None
        result_intersection_indexes = []
        if len(convex_hull_points_allowed) > 0:
            convex_hull_allowed_best_loss_point_indexes = self.__get_best_loss_point_idx(convex_hull_points_allowed)
            if len(convex_hull_allowed_best_loss_point_indexes) > 0:
                convex_hull_best_loss_point_indexes = convex_hull_indexes_allowed[
                    convex_hull_allowed_best_loss_point_indexes]
                matrix_best_loss_point_indexes = convex_hull_indexes[convex_hull_best_loss_point_indexes]
                result_indexes.extend(matrix_best_loss_point_indexes)
                result_loss = matrix[matrix_best_loss_point_indexes[0]][self.uncontrolled_state_idx]

            p1_convex_hull_idx, p2_convex_hull_idx, intersection_k, intersection_loss = self.__get_best_intersection_loss(
                convex_hull_points,
                value
            )
            if intersection_loss is not None:
                p1_matrix_idx = convex_hull_indexes[p1_convex_hull_idx]
                p2_matrix_idx = convex_hull_indexes[p2_convex_hull_idx]
                intersection_loss = round(intersection_loss, self._accuracy)
                intersection_k = round(intersection_k, self._accuracy)
                if result_loss is None or result_loss + eps > intersection_loss:
                    # intersection loss less or equal
                    result_intersection_indexes.append(p1_matrix_idx)
                    result_intersection_indexes.append(p2_matrix_idx)
                    result_k = intersection_k
                    if result_loss is None or result_loss - eps > intersection_loss:
                        # intersection loss is less (strict)
                        result_indexes = []
                        result_loss = intersection_loss

        return result_indexes, result_loss, result_k, result_intersection_indexes, value


if __name__ == '__main__':
    triangle_down = np.array([[1, 2], [3, 2], [2, 1]])
    triangle_up = np.array([[1, 1], [3, 1], [2, 2]])

    solver = NeymanPirsRandomizedSolver()
    solver.take_input_win_matrix_ = False

    print(solver.solve(triangle_down, value=4) == ([2], 1, None, [], 4))
    print(solver.solve(triangle_down, value=0) == ([], None, None, [], 0))
    print(solver.solve(triangle_down, value=1) == ([0], 2, None, [], 1))
    print(solver.solve(triangle_down, value=2) == ([2], 1, None, [], 2))
    print(solver.solve(triangle_down, value=1.5) == ([], 1.5, 0.5, [0, 2], 1.5))
    print(solver.solve(triangle_down, value=2.5) == ([2], 1, None, [], 2.5))

    print(solver.solve(triangle_up, value=4) == ([0, 1], 1, None, [], 4))
    print(solver.solve(triangle_up, value=2) == ([0], 1, 0.5, [0, 1], 2))
