import numpy as np

from solvers.base_solver import BaseSolver


class NeymanPirsSolver(BaseSolver):
    def __init__(self, accuracy=2):
        super().__init__(accuracy)

    def check(self, matrix):
        num_rows, num_column = matrix.shape
        if num_column != 2:
            raise Exception('Matrix is not valid!')

    def _solve(self, matrix, **kwargs):
        if 'critical_value' not in kwargs:
            raise Exception('critical_value must be provided for Neyman-Pirson method')
        critical_value = kwargs['critical_value']
        self.check(matrix)

        deleted_rows = []
        for i in range(len(matrix)):
            if matrix[i][0] > critical_value:
                deleted_rows.append(i)

        res = 100000
        for i in range(len(matrix)):
            if matrix[i][1] < res and i not in deleted_rows:
                res = matrix[i][1]

        indexes = []
        loss = None
        if res < 100000:
            indexes = np.flatnonzero(matrix[:, 1] == res).tolist()
            loss = res

        result = {
            'indexes_optimal': indexes,
            'loss': loss,
            'indexes_excluded': deleted_rows,
            'critical_value': float(critical_value)
        }

        return result


if __name__ == '__main__':
    mewCl = NeymanPirsSolver()
    mewCl.take_input_win_matrix_ = False
    print(mewCl.solve(np.array([[3, 5], [4, 6], [2, 3], [1, 3], [7, 1]]), critical_value=4))
