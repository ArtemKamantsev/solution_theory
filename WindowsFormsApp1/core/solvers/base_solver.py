from abc import ABC, abstractmethod

import numpy as np


class BaseSolver(ABC):
    def __init__(self, accuracy=2):
        self._accuracy = accuracy
        self.take_input_win_matrix_ = True

    def __revert(self, matrix):
        maxi = np.amax(matrix)

        for row in range(len(matrix)):
            for el in range(len(matrix[row])):
                matrix[row][el] = round(maxi - matrix[row][el], self._accuracy)
        return matrix

    def solve(self, matrix, **kwargs):
        if matrix is None or type(matrix) is not np.ndarray or matrix.ndim != 2 or len(matrix) == 0:
            raise Exception('Matrix is not valid!')

        if self.take_input_win_matrix_:
            matrix = self.__revert(matrix)

        result_child = self._solve(matrix, **kwargs)

        return {
            'matrix_loss': matrix.tolist(),
            **result_child,
        }

    @abstractmethod
    def _solve(self, matrix, **kwargs):
        pass
