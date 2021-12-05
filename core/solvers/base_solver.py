from abc import ABC, abstractmethod

import numpy as np


class BaseSolver(ABC):
    def solve(self, matrix, **kwargs):
        if matrix is None or type(matrix) is not np.ndarray or matrix.ndim != 2:
            raise Exception('Matrix is not valid!')

        return self._solve(matrix, **kwargs)

    @abstractmethod
    def _solve(self, matrix, **kwargs):
        pass
