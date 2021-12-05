import numpy as np

eps = 1e-10


def jarvis(points):
    if len(points) < 2:
        return np.array(range(len(points)))

    # STEP 1: find first point
    result = [np.argmin(points[:, 1])]

    # STEP 2: find second point
    # calculate polar angels of points if first point is center
    temp_vectors = points - points[result[-1]]
    polar_angles = np.arctan2(temp_vectors[:, 1], temp_vectors[:, 0])

    # find point with smaller polar angle
    polar_min = float('inf')
    polar_min_index = -1
    for current_index, angle in enumerate(polar_angles):
        if current_index == result[-1]:
            continue

        # if two points lie on the same line - choose the closest
        elif abs(angle - polar_min) < eps and \
                np.linalg.norm(points[result[-1]] - points[polar_min_index]) - np.linalg.norm(points[result[-1]] - points[current_index]) > eps:

            polar_min_index = current_index

        elif polar_min - angle > eps :
            polar_min = angle
            polar_min_index = current_index

    result.append(polar_min_index)

    # STEP 3: find others point while stumble first point
    while True:
        cos_max = float('-inf')
        cos_max_index = -1
        last_vector = points[result[-1]] - points[result[-2]]
        for current_index, point in enumerate(points):
            if current_index in result[1:]:
                continue

            current_vector = point - points[result[-1]]

            current_cos = np.dot(last_vector, current_vector) / np.linalg.norm(last_vector) / np.linalg.norm(current_vector)

            # if two points lie on the same line - choose the closest
            if abs(current_cos - cos_max) < eps and \
                    np.linalg.norm(points[result[-1]] - points[cos_max_index]) - np.linalg.norm(current_vector) > eps :

                cos_max_index = current_index

            elif current_cos - cos_max > eps:
                cos_max = current_cos
                cos_max_index = current_index

        if cos_max_index == result[0]:
            break

        result.append(cos_max_index)

    return result


def main():
    points = np.array([[0, 1], [0, 2], [0, 3], [1, 1], [0, 4], [2, 2], [2, 3], [4, 4]])

    # expected result: [0, 3, 5, 7, 4, 2, 1]
    points_mask = jarvis(points)

    print(points_mask)


if __name__ == '__main__':
    main()
