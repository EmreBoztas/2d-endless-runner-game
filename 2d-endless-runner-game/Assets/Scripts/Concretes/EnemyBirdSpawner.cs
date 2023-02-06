using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdSpawner : BaseSpawner
{
    [SerializeField] private GameObject _bird;
    [SerializeField] private GameObject _penguinSpawner;
     protected override void Spawn(){
        Instantiate(_bird, transform.position, Quaternion.Euler(0,180,0));
        _penguinSpawner.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
