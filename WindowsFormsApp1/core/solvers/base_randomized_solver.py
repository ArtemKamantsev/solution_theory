from abc import ABC, abstractmethod

from solvers.base_solver import BaseSolver
from utils import jarvis


class SolutionCounts:
    NONE = 'NONE'
    SINGLE = 'SINGLE'
    INFINITE = 'INFINITE'


class BaseRandomizedSolver(BaseSolver, ABC):
    def __init__(self, accuracy):
        super().__init__(accuracy)

    def _solve(self, matrix, **kwargs):
        if matrix.shape[1] != 2:
            raise Exception('Matrix is not valid!')

        convex_hull_indexes = jarvis(matrix)

        result_child = self._solve_randomized(matrix, convex_hull_indexes, **kwargs)

        def get_empty_x():
            return [0] * len(matrix)

        if len(result_child['indexes_optimal']) == 1 and len(result_child['indexes_intersection']) == 0:
            solution_counts = SolutionCounts.SINGLE
            x = get_empty_x()
            optimal_idx = result_child['indexes_optimal'][0]
            x[optimal_idx] = 1
        elif len(result_child['indexes_optimal']) == 0 and len(result_child['indexes_intersection']) == 2:
            solution_counts = SolutionCounts.SINGLE
            x = get_empty_x()
            optimal_idx1, optimal_idx2 = result_child['indexes_intersection']
            x[optimal_idx1] = result_child['intersection_ratio']
            x[optimal_idx2] = round(1 - result_child['intersection_ratio'], self._accuracy)
        elif result_child['loss'] is None:
            solution_counts = SolutionCounts.NONE
            x = []
        else:
            solution_counts = SolutionCounts.INFINITE
            x = []

        return {
            'indexes_convex_hull': convex_hull_indexes.tolist(),
            'solution_counts': solution_counts,
            'X': x,
            **result_child,
        }

    @abstractmethod
    def _solve_randomized(self, matrix, convex_hull_indexes, **kwargs):
        pass
