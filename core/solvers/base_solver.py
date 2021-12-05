from abc import ABC, abstractmethod

import numpy as np


class BaseSolver(ABC):

    def solve(self, matrix):
        if matrix is None or type(matrix) is not np.ndarray:
            raise Exception('Matrix is not valid!')

        return self._solve(matrix)

    @abstractmethod
    def _solve(self, matrix):
        pass
