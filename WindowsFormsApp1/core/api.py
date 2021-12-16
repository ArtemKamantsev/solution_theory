import json

import numpy as np

from solvers.min_max_randomized_solver import MinMaxRandomizedSolver
from solvers.min_max_solver import MinMaxSolver
from solvers.neyman_pirs_randomized_solver import NeymanPirsRandomizedSolver
from solvers.neyman_pirs_solver import NeymanPirsSolver

solvers = {
    'min-max': MinMaxSolver(),
    'neyman-pirson': NeymanPirsSolver(),
    'min-max-randomized': MinMaxRandomizedSolver(),
    'neyman-pirson-randomized': NeymanPirsRandomizedSolver(),
}


def get_solver():
    solver_key = input()
    if solver_key in solvers:
        return solvers[solver_key]

    raise Exception(f'Unsupported key. You can input any of: {str(list(solvers.keys()))}')


def get_params():
    params_string = input()
    params = json.loads(params_string)

    return params


def get_matrix_from_params(params):
    if 'matrix' not in params or type(params['matrix']) is not list:
        raise Exception('Parameters should contain key "matrix" with value of 2 dimensional matrix')

    matrix = params['matrix']
    del params['matrix']

    return np.array(matrix), params


if __name__ == '__main__':
    data = None
    exception = None
    try:
        solver = get_solver()
        params = get_params()
        matrix, params = get_matrix_from_params(params)

        data = solver.solve(matrix, **params)
    except Exception as e:
        exception = str(e)

    response = json.dumps({
        "data": data,
        "exception": exception,
    })

    print(response)
