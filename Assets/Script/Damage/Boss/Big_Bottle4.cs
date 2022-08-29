using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Bottle4 : MonoBehaviour
{
    public GameObject Boss1;

    Boss4 Boss;
    Rigidbody2D Rd;
    Player player;

    private int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        Boss = Boss1.GetComponent<Boss4>(); //������ Ŭ���� ��������
        Rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rd.velocity = new Vector2(-4f, 0f); //�·� �̵��ϴ� ����
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle") //���̶� �浹�ϸ� ��Ȱ��ȭ
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