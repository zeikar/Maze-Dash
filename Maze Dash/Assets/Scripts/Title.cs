using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Text inputField;

    public void GoToGameScene()
    {
        Player player = new Player(inputField.text);

        GameManager.instance.InitGame(player);
    }
}
