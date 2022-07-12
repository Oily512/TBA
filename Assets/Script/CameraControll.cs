using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private GameObject Player;

    public float cameraSpeed = 5.0f;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        move = Player.transform.position - this.transform.position;
        this.transform.Translate(move.x, 0, 0);            
    }
}
