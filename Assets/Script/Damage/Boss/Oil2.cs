using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil2 : MonoBehaviour
{
    Rigidbody2D Rd;
    Player player;

    private int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rd.velocity = new Vector2(-4f, 0f); //좌로 이동하는 성질
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle") //벽이랑 충돌하면 삭제
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
