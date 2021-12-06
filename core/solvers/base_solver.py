from abc import ABC, abstractmethod

import numpy as np


class BaseSolver(ABC):
    def __init__(self):
        self.take_input_win_matrix_ = True

    def __revert(self, matrix):
        maxi = np.amax(matrix)

        for row in range(len(matrix)):
            for el in range(len(matrix[row])):
                matrix[row][el] = maxi - matrix[row][el]
        return matrix

    def solve(self, matrix, **kwargs):
        if matrix is None or type(matrix) is not np.ndarray or matrix.ndim != 2:
            raise Exception('Matrix is not valid!')

        if self.take_input_win_matrix_:
            matrix = self.__revert(matrix)

        return self._solve(matrix, **kwargs)

    @abstractmethod
    def _solve(self, matrix, **kwargs):
        pass
