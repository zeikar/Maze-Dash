using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameClear();
    }
}
