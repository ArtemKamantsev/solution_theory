import numpy as np

from solvers.base_solver import BaseSolver


class MinMaxSolver(BaseSolver):
    def _solve(self, matrix, **kwargs):
        matrix_max = np.array([])
        for row in range(len(matrix)):
            matrix_max = np.append(matrix_max, max(matrix[row]))

        res = min(matrix_max)
        indexes = np.flatnonzero(matrix_max == res)
        result = {'indexes_optimal:': indexes, 'loss:': res}

        return result


mewCl = MinMaxSolver()
mewCl.take_input_win_matrix_ = False
print(mewCl.solve(np.array([[1, 2], [2, 2], [5, 6]])))
