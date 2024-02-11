using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaCreater : MonoBehaviour
{
    [SerializeField] private float _minX, _maxX, _interval;
    [SerializeField] private GameObject[] _obstacles;
    // Start is called before the first frame update
    void Start()
    {
        int obstacleCount = Random.Range(2, 10);

        Vector3 position = new Vector3(_minX, 0, 0);

        for(int i = 0 ; i < obstacleCount ; ++i)
        {
            var obstacle = _obstacles[Random.Range(0, _obstacles.Length)];
            Instantiate(obstacle, transform.position + position, Quaternion.identity, transform);

            position.x += Random.Range(1, obstacleCount - i) * _interval;
        }

        position.x = _maxX;
        var lastObstacle = _obstacles[Random.Range(0, _obstacles.Length)];
        Instantiate(lastObstacle, transform.position + position, Quaternion.identity, transform);
    }
}
