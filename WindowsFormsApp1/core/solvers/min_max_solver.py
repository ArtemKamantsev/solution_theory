import numpy as np

from solvers.base_solver import BaseSolver


class MinMaxSolver(BaseSolver):
    def __init__(self, accuracy=2):
            super().__init__(accuracy)
            
    def _solve(self, matrix, **kwargs):
        matrix_max = np.array([])
        for row in range(len(matrix)):
            matrix_max = np.append(matrix_max, max(matrix[row]))

        res = min(matrix_max)
        indexes = np.flatnonzero(matrix_max == res)
        result = {
            'indexes_optimal': indexes.tolist(),
            'loss': float(res)
        }

        return result


if __name__ == '__main__':
    mewCl = MinMaxSolver()
    mewCl.take_input_win_matrix_ = False
    print(mewCl.solve(np.array([[1, 2], [2, 2], [5, 6]])))
