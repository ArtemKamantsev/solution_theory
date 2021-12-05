from Jarvis import jarvis, eps
from solvers.base_solver import BaseSolver


# {
# “loss_matrix”:list<list<double>>,
# “intersection_point_indexes”:list<int>,
# “x”:double ,
# “x_star”:list<double>,
# “loss_star”: list<double>,
# }

class MinMaxSolver(BaseSolver):

    def __get_wedge_intersection_indexes(self, convex_hull_points, point_dimension):
        convex_hull_axis_values = convex_hull_points[:, point_dimension]
        min_value = convex_hull_axis_values.min()
        indexes = (convex_hull_axis_values == min_value).nonzero()

        return indexes

    def __get_mean_line_intersection(self, convex_hull_points):
        if len(convex_hull_points) == 0:
            return [], None, None

        intersection_indexes = None
        intersection_k = None
        intersection_loss = None

        def is_on_mean_line(point):
            return abs(point[0] - point[1]) < eps

        if is_on_mean_line(convex_hull_points[0]):
            intersection_indexes = [0]
            intersection_loss = convex_hull_points[0][0]

        for idx in range(1, len(convex_hull_points)):
            prev_point = convex_hull_points[idx - 1]
            total_point = convex_hull_points[idx]

            if is_on_mean_line(total_point) and total_point[0] < intersection_loss:
                intersection_indexes = [idx]
                intersection_k = None
                intersection_loss = total_point[0]

            nominator = total_point[1] - total_point[0]
            denominator = prev_point[0] - total_point[0] - prev_point[1] + total_point[1]
            if abs(denominator) > eps:
                k = nominator / denominator
                if 0 < k < 1:
                    total_loss = prev_point[0] * k + total_point[0] * (1 - k)
                    if intersection_loss is None or total_loss < intersection_loss:
                        intersection_indexes = [idx - 1, idx]
                        intersection_k = k
                        intersection_loss = total_loss

        return intersection_indexes, intersection_k, intersection_loss

    def _solve(self, matrix):
        convex_hull_indexes = jarvis(matrix)
        convex_hull_points = matrix[convex_hull_indexes]

        convex_hull_top_points_indexes = (convex_hull_points[:, 0] < convex_hull_points[:, 1]).nonzero()
        top_matrix_indexes, top_loss = None, None
        if len(convex_hull_top_points_indexes) > 0:
            convex_hull_top_points = convex_hull_points[convex_hull_top_points_indexes]
            intersection_top_indexes = self.__get_wedge_intersection_indexes(convex_hull_top_points, point_dimension=1)
            if len(intersection_top_indexes) > 0:
                intersection_convex_hull_indexes = convex_hull_top_points_indexes[intersection_top_indexes]
                top_matrix_indexes = convex_hull_indexes[intersection_convex_hull_indexes]
                top_loss = matrix[top_matrix_indexes[0]][0]



        convex_hull_bottom_points_indexes = (convex_hull_points[:, 0] > convex_hull_points[:, 1]).nonzero()
        bottom_matrix_indexes, bottom_loss = None, None
        if len(convex_hull_bottom_points_indexes) > 0:
            convex_hull_bottom_points = convex_hull_points[convex_hull_bottom_points_indexes]
            intersection_bottom_indexes = self.__get_wedge_intersection_indexes(convex_hull_bottom_points, point_dimension=0)
            if len(intersection_bottom_indexes) > 0:
                intersection_convex_hull_indexes = convex_hull_bottom_points_indexes[intersection_bottom_indexes]
                bottom_matrix_indexes = convex_hull_indexes[intersection_convex_hull_indexes]
                bottom_loss = matrix[bottom_matrix_indexes[0]][0]

        mean_line_intersection_indexes, intersection_k, mean_line_loss = self.__get_mean_line_intersection(
            convex_hull_points
        )
        mean_line_matrix_indexes = None
        if len(mean_line_intersection_indexes) > 0:
            mean_line_matrix_indexes = convex_hull_indexes[mean_line_intersection_indexes]



