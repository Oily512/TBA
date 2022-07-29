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
        Rd.velocity = new Vector2(-4f, 0f); //�·� �̵��ϴ� ����
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle") //���̶� �浹�ϸ� ����
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
