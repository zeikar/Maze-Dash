using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Transform player;

    Animator cameraAnime;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCamera").transform;
        cameraAnime = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.position;
        Vector3 offset = player.TransformDirection(new Vector3(0.0f, 1.0f, -1.0f));
        RaycastHit hit;

        if (Physics.Raycast(player.position, offset, out hit, offset.sqrMagnitude))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, hit.point.y, hit.point.z), 0.1f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pos + offset, 0.1f);
        }


        //transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, 0.1f);
        transform.LookAt(player);
    }

    public void CameraGameOver()
    {
        cameraAnime.SetTrigger("GameOver");
    }

    public void CameraGameClear()
    {
        cameraAnime.SetTrigger("GameClear");
    }
}
