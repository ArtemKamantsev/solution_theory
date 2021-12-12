import numpy as np

eps = 1e-10


def jarvis(points):
    if len(points) < 2:
        return np.array(range(len(points)))

    result = [np.argmin(points[:, 1])]

    # Second point search
    translated_points = points - points[result[0]]
    angles = np.arctan2(translated_points[:, 1], translated_points[:, 0])

    # Search for point with smallest angle
    angle_min_idx = -1
    angle_min = float('inf')
    for idx, angle in enumerate(angles):
        if idx == result[-1]:
            continue

        if angle_min - angle > eps:
            angle_min = angle
            angle_min_idx = idx
        elif abs(angle - angle_min) < eps and \
                np.linalg.norm(points[result[-1]] - points[angle_min_idx]) - \
                np.linalg.norm(points[result[-1]] - points[idx]) > eps:
            angle_min_idx = idx

    result.append(angle_min_idx)

    # Find the rest of the points
    while True:
        cos_max_index = -1
        cos_max = float('-inf')
        last_vector = points[result[-1]] - points[result[-2]]
        for idx, point in enumerate(points):
            if idx in result[1:]:
                continue

            current_vector = point - points[result[-1]]

            current_cos = np.dot(last_vector, current_vector) / \
                          (np.linalg.norm(last_vector) * np.linalg.norm(current_vector))

            if current_cos - cos_max > eps:
                cos_max = current_cos
                cos_max_index = idx
            elif abs(current_cos - cos_max) < eps and \
                    np.linalg.norm(points[result[-1]] - points[cos_max_index]) - np.linalg.norm(current_vector) > eps:
                cos_max_index = idx

        if cos_max_index == result[0]:
            break

        result.append(cos_max_index)

    return np.array(result)


if __name__ == '__main__':
    points = np.array([[0, 1], [0, 2], [0, 3], [1, 1], [0, 4], [2, 2], [2, 3], [4, 4]])
    convex_hull_indexes = jarvis(points)

    print(list(convex_hull_indexes) == [0, 3, 5, 7, 4, 2, 1])
