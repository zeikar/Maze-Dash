using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Vector3 originPos, newPos;
    float currentTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 20.0f)
        {
            SoundManager.instance.StopBlockSound();
            currentTime = 0.0f;
        }
        else if(currentTime >= 15.0f)
        {
            SoundManager.instance.StopBlockSound();
            return;
        }
        else if (currentTime >= 10.0f)
        {
            SoundManager.instance.PlayBlockSound();
            transform.Translate((originPos - newPos) / (5.0f / Time.deltaTime));
        }
        else if (currentTime >= 5.0f)
        {
            SoundManager.instance.StopBlockSound();
            return;
        }
        else
        {
            SoundManager.instance.PlayBlockSound();
            transform.Translate((newPos - originPos) / (5.0f / Time.deltaTime));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameOver();
    }
}
