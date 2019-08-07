using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject gamescore;
    public Text score;
    public FloorBehaviour scores;

    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().Death += GameOverScreen;
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

      void GameOverScreen()
    {
        score.text = scores.score.ToString();
        gamescore.SetActive(false);
        gameOver.SetActive(true);
        isGameOver = true;
    }
}
