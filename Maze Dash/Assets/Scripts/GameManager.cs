using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    CharacterControl characterControl;
    CameraControl cameraControl;

    Player currentPlayer;

    bool isPlaying = false;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void InitGame(Player player)
    {
        currentPlayer = player;
        isPlaying = true;

        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (isPlaying)
        {
            currentPlayer.setTime(currentPlayer.getTime() + Time.deltaTime);
        }

    }

    public void GameOver()
    {
        if (isPlaying == false)
        {
            return;
        }

        characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();

        characterControl.Die();
        cameraControl.CameraGameOver();

        isPlaying = false;

        LeaderBoardUI.instance.printGameOver(true);

        SoundManager.instance.StopBackgroundMusic();
        SoundManager.instance.PlayGameOverSound();
    }

    public void GameClear()
    {
        if (isPlaying == false)
        {
            return;
        }

        characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();

        characterControl.Win();
        cameraControl.CameraGameClear();

        isPlaying = false;

        LeaderBoard.instance.addPlayer(currentPlayer);
        LeaderBoardUI.instance.printGameOver(false);

        SoundManager.instance.StopBackgroundMusic();
        SoundManager.instance.PlayGameClearSound();
    }
}
