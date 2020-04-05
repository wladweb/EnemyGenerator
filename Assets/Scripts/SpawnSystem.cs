using UnityEngine;
using System.Collections;

public class SpawnSystem : MonoBehaviour
{
    private SpawnPoint[] _spawnPoints;
    private int _currentIndex;

    private int CurrentIndex
    {
        get
        {
            return _currentIndex;
        }
        set
        {
            if (value >= _spawnPoints.Length)
            {
                _currentIndex = 0;
            }
            else
            {
                _currentIndex = value;
            }
        }
    }

    private void Start()
    {
        _spawnPoints = transform.GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            SpawnPoint spawnPoint = _spawnPoints[CurrentIndex++];
            spawnPoint.SpawnEnemy();

            yield return new WaitForSeconds(2);
        }
    }
}
