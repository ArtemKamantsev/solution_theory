import numpy as np

from solvers.base_solver import BaseSolver


class MinMaxSolver(BaseSolver):
    def _solve(self, matrix, **kwargs):
        matrix_max = np.array([])
        for row in range(len(matrix)):
            matrix_max = np.append(matrix_max, max(matrix[row]))

        res = min(matrix_max)
        index = np.argmin(matrix_max)
        print(res, index)


mewCl = MinMaxSolver()
mewCl.solve(np.array([[1, 2], [5, 6]]))
