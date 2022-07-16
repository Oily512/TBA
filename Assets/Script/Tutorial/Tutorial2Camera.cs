using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraSpeed = 5.0f;
    public GameObject Fance;


    private bool Triger = false;
    private float time = 0f;
    private GameObject Player;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Triger == false)
        {
            time += Time.deltaTime;
            if (time >= 3f)
            {
                Fance.SetActive(false);
                Triger = true;
            }
        }
        else
        {
            move = Player.transform.position - this.transform.position;
            this.transform.Translate(move.x, 0, 0);
        }
    }
}
