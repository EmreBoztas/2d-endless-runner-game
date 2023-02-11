using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{   
    [SerializeField] private TMP_Text _scoreText;
    public int _score;
    
    private void Start()
    {
        _score = 0;
        InvokeRepeating("IncreaseScore", 5f, 5f);
    }

    public void StopScore()
    {
         CancelInvoke();
    }

    private void IncreaseScore()
    {
        _score += 5;
        _scoreText.text = "Score: " + _score;
        GameObject[] bgs = GameObject.FindGameObjectsWithTag("Background");
        foreach(GameObject bg in bgs)
        {
            RepeatBackground repeatBackground = bg.GetComponent<RepeatBackground>();
            repeatBackground.ChangeSpeed((float)_score);
        }
    }

    public void RestartLevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
