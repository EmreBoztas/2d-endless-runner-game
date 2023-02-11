using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animation _animation;
    private GameObject[] _spawner;
    GameManager gameManager;
    
    [SerializeField] private float _speed = 10;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 5);
        _speed  = _speed + gameManager._score / 100;
    }

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

            GameObject gameOverPanel = GameObject.Find("GameCanvas").transform.GetChild(0).gameObject;
            gameOverPanel.SetActive(true);
            
            for(int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            StopGame();
        }
    }

    private void StopGame()
    {
        gameManager.StopScore();
        _animation = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>();
        _animation.Die();
        _spawner = GameObject.FindGameObjectsWithTag("Spawner");
        for(int i=0; i < _spawner.Length; i++)
        {
            _spawner[i].SetActive(false);
        }
    }
}
