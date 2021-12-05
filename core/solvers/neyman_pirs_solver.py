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

        for i in range(len(matrix[0])):
            if matrix[i][0] > value:
                deleted_rows.append(i)

        res = 100000
        index = -1
        for i in range(len(matrix[1])):
            if matrix[i][1] < res and i not in deleted_rows:
                res = matrix[i][1]
                index = i

        print(res, index)


mewCl = NeymanPirsSolver()
mewCl.solve(np.array([[3, 5], [4, 6], [2, 3], [7, 1]]), value=4)
