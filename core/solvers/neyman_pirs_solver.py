import numpy as np
from abc import ABC
from solvers.base_solver import BaseSolver


class NeymanPirsSolver(ABC):
    def check(self, matrix):
        num_rows, num_column = matrix.shape
        if num_column != 2:
            raise Exception('Matrix is not valid!')

        if matrix is None or type(matrix) is not np.ndarray:
            raise Exception('Matrix is not valid!')


    def revert(self, matrix):
        maxi = np.amax(matrix)

        for row in range(len(matrix)):
            for el in range(len(matrix[row])):
                matrix[row][el] = maxi - matrix[row][el]
        return matrix

    def solve(self, matrix, value):
        self.check(matrix)

        matrix = self.revert(matrix)

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
mewCl.solve(np.array([[3, 5], [4, 6], [2, 3], [7, 1]]), 4)