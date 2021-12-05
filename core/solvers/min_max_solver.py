import numpy as np
from solvers.base_solver import BaseSolver


class MinMaxSolver(BaseSolver):
    def revert(self, matrix):
        maxi = np.amax(matrix)

        for row in range(len(matrix)):
            for el in range(len(matrix[row])):
                matrix[row][el] = maxi - matrix[row][el]
        return matrix

    def _solve(self, matrix, **kwargs):
        matrix = self.revert(matrix)
        matrix_max = np.array([])
        for row in range(len(matrix)):
            matrix_max = np.append(matrix_max, max(matrix[row]))

        res = min(matrix_max)
        index = np.argmin(matrix_max)
        pass

mewCl = MinMaxSolver()
mewCl.solve(np.array([[1, 2],[5, 6]]))