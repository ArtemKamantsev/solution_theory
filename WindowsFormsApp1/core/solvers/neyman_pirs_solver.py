import numpy as np

from solvers.base_solver import BaseSolver


class NeymanPirsSolver(BaseSolver):
    def check(self, matrix):
        num_rows, num_column = matrix.shape
        if num_column != 2:
            raise Exception('Matrix is not valid!')

    def _solve(self, matrix, **kwargs):
        value = kwargs['value']
        self.check(matrix)

        deleted_rows = []
        for i in range(len(matrix)):
            if matrix[i][0] > value:
                deleted_rows.append(i)

        res = 100000
        for i in range(len(matrix)):
            if matrix[i][1] < res and i not in deleted_rows:
                res = matrix[i][1]

        indexes = np.flatnonzero(matrix[:, 1] == res)
        result = {'indexes_optimal:': indexes, 'loss:': res, 'indexes_excluded': deleted_rows}

        return result


mewCl = NeymanPirsSolver()
mewCl.take_input_win_matrix_ = False
print(mewCl.solve(np.array([[3, 5], [4, 6], [2, 3], [1, 3], [7, 1]]), value=4))
