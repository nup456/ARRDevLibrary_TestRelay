using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPoint;
    [SerializeField] private float _minSpawnTime, _maxSpawnTime;

    [SerializeField] private GameObject[] _carPrefabs;
    [SerializeField] private Vector3 _carLookAngle = new(0, 90, 0);

    private void Start() { StartCoroutine(Spawn()); }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_spawnPoint, 0.5f);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            float _spawnInterval = Random.Range(_minSpawnTime, _maxSpawnTime);
            yield return new WaitForSeconds(_spawnInterval);
            
            var carPrefab = _carPrefabs[Random.Range(0, _carPrefabs.Length)];
            var car = Instantiate(carPrefab, transform.position + _spawnPoint, quaternion.identity, transform);
            car.transform.rotation = Quaternion.Euler(_carLookAngle);
        }
    }
}