using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int _score;

    private void Start()
    {
        _score = 0;
        InvokeRepeating("IncreaseScore", 5f, 5f);
    }

    private void IncreaseScore()
    {
        _score += 5;
    }

    public void RestartLevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
