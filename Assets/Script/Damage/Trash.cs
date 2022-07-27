using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 dir;
    private float T = 0f;

    GameObject Monster;
    Transform monster_T;
    Heart monster_S;
    Rigidbody2D rd;
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        Monster = GameObject.FindGameObjectWithTag("Monster");
        monster_T = Monster.GetComponent<Transform>();
        monster_S = Monster.GetComponent<Heart>();
        rd = GetComponent<Rigidbody2D>();

        dir = monster_T.rotation.eulerAngles;
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
        if (other.gameObject.CompareTag("Player"))
        {
            Player = other.GetComponent<Player>();
            Player.TakeDamage(monster_S.damage);

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}