using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    CharacterControl characterControl;
    CameraControl cameraControl;

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

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    private void InitGame()
    {
        characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
    }

    public void GameOver()
    {
        characterControl.Die();
        cameraControl.CameraGameOver();
    }

    public void GameClear()
    {
        characterControl.Win();
        cameraControl.CameraGameClear();
    }
}
