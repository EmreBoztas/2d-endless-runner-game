using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPenguinSpawner : BaseSpawner
{
    [SerializeField] private GameObject _penguin;
    [SerializeField] private GameObject _birdSpawner;
     protected override void Spawn(){
        Instantiate(_penguin, transform.position, Quaternion.Euler(0,180,0));
        _birdSpawner.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
