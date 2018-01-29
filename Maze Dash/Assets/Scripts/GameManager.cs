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

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
            cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
        }
    }

    public void InitGame(Player player)
    {
        currentPlayer = player;
        isPlaying = true;

        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if(isPlaying)
        {
            currentPlayer.setTime(currentPlayer.getTime() + Time.deltaTime);

            Debug.Log(currentPlayer.getName() + currentPlayer.getTime());
        }

    }

    public void GameOver()
    {
        characterControl.Die();
        cameraControl.CameraGameOver();

        isPlaying = false;
    }

    public void GameClear()
    {
        characterControl.Win();
        cameraControl.CameraGameClear();

        isPlaying = false;

        LeaderBoard.instance.addPlayer(currentPlayer);
    }
}
