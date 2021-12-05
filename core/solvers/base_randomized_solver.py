from abc import ABC, abstractmethod

from solvers.base_solver import BaseSolver


class BaseRandomizedSolver(BaseSolver, ABC):
    def __init__(self, accuracy):
        self._accuracy = accuracy

    def _solve(self, matrix, **kwargs):
        if matrix.shape[1] != 2:
            raise Exception('Matrix is not valid!')

        return self._solve_randomized(matrix, **kwargs)

    @abstractmethod
    def _solve_randomized(self, matrix, **kwargs):
        pass
