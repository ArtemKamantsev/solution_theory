from abc import ABC

from solvers.base_solver import BaseSolver


class BaseRandomizedSolver(ABC, BaseSolver):
    def solve(self, matrix):
        if matrix.ndim != 2 or matrix.shape[1] != 2:
            raise Exception('Matrix is not valid!')

        return self._solve(matrix)
