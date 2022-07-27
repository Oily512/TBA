using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 dir;
    private float T = 0f;

    Transform Player;
    Rigidbody2D rd;
    Heart Hrt;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rd = GetComponent<Rigidbody2D>();

        dir = Player.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        T += Time.deltaTime;

        if (dir[1] <= 0)
        {
            rd.velocity = new Vector2(speed, 0f);
        }
        else if (dir[1] > 0)
        {
            rd.velocity = new Vector2(-speed, 0f);
        }

        if (T >= 2f) //사거리 설정.
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Hrt = other.GetComponent<Heart>();
            Hrt.TakeDamage(3);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
