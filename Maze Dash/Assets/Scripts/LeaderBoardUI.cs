using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoardUI : MonoBehaviour
{
    public static LeaderBoardUI instance = null;

    public GameObject canvas;
    public Text gameOverText;
    public GameObject creditUI;

    public GameObject leaderBoardText;
    public Transform leaderBoardContent;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canvas.SetActive(false);
        creditUI.SetActive(false);
    }

    public void printGameOver(bool gameOver)
    {
        canvas.SetActive(true);

        if (gameOver)
        {
            gameOverText.text = "Game Over...T_T";
        }
        else
        {
            gameOverText.text = "Game Clear! >.<";
        }
    }

    public void printLeaderBoard(List<Player> list)
    {        
        for (int i = 0; i < leaderBoardContent.childCount; ++i)
        {
            Destroy(leaderBoardContent.GetChild(i).gameObject);
        }

        foreach (Player player in list)
        {
            Instantiate(leaderBoardText, leaderBoardContent).GetComponent<Text>().text = player.getName() + " : " + ((int)(player.getTime() * 10) / 10.0f);
        }        
    }

    public void toTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void credits()
    {
        creditUI.SetActive(true);
    }
    
    public void creditsClose()
    {
        creditUI.SetActive(false);
    }
}
