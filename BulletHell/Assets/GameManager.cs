using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int Lives = 2;
    [SerializeField]
    public Text LivesText;
    [SerializeField]
    public Text ScoreText;

    [SerializeField]
    public GameObject Player;

    private void Start()
    {

    }

    public void LostLife()
    {
        Lives--;
        LivesText.text = "Lives " + Lives;
        if (Lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
