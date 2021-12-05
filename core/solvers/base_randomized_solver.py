from abc import ABC, abstractmethod

from solvers.base_solver import BaseSolver


class BaseRandomizedSolver(BaseSolver, ABC):
    def __init__(self, accuracy):
        self.accuracy = accuracy

    def _solve(self, matrix):
        if matrix.ndim != 2 or matrix.shape[1] != 2:
            raise Exception('Matrix is not valid!')

        return self._solve_randomized(matrix)

    @abstractmethod
    def _solve_randomized(self, matrix):
        pass
