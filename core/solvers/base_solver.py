from abc import ABC, abstractmethod

import numpy as np


class BaseSolver(ABC):

    def solve(self, matrix):
        if not matrix or type(matrix) is not np.ndarray or matrix.ndim != 2 or matrix.shape[1] != 2:
            raise Exception('Matrix is not valid!')

        return self._solve(matrix)

    @abstractmethod
    def _solve(self, matrix):
        pass
