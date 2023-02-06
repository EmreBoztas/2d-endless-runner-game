using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    [Range(1f,10f)]
    [SerializeField] float _maxSpawnTime = 3f;
    [Range(0f,5.5f)]
    [SerializeField] float _minSpawnTime = 1f;

    float _currentSpawnTime;
    float _timeBoundary;

    private void Start() {
        ResetTimes();
    }

    private void Update() {
        _currentSpawnTime += Time.deltaTime;

        if (_currentSpawnTime > _timeBoundary)
        {
            Spawn();
            ResetTimes();             
        }
    }

    protected abstract void Spawn();
       
    private void ResetTimes(){
        _currentSpawnTime = 0f;
        _timeBoundary = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
