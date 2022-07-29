using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Gun3 : MonoBehaviour
{
    public GameObject Boss1;

    Boss3 Boss;
    Rigidbody2D Rd;
    Player player;

    private int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Boss = Boss1.GetComponent<Boss3>(); //보스의 클래스 가져오기
        Rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rd.velocity = new Vector2(-4f, 0f); //좌로 이동하는 성질
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle") //벽이랑 충돌하면 비활성화
        {
            Boss.W = false;
            gameObject.SetActive(false);
        }

        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }
}
