from abc import ABC, abstractmethod

from utils import jarvis
from solvers.base_solver import BaseSolver


class BaseRandomizedSolver(BaseSolver, ABC):
    def __init__(self, accuracy):
        super().__init__()
        self._accuracy = accuracy

    def _solve(self, matrix, **kwargs):
        if matrix.shape[1] != 2:
            raise Exception('Matrix is not valid!')

        convex_hull_indexes = jarvis(matrix)

        return self._solve_randomized(matrix, convex_hull_indexes, **kwargs)

    @abstractmethod
    def _solve_randomized(self, matrix, convex_hull_indexes, **kwargs):
        pass
