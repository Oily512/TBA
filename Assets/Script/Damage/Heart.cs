using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart: MonoBehaviour
{
    public int heart = 10;
    public int damage = 3;
    public float v = 1f;
    public float ran = 8f; //이동 범위

    private float point; //현재 x좌표

    Rigidbody2D Rd;

    // Start is called before the first frame update
    void Start()
    {
        point = transform.position.x;
        Rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move() //좌우로 번갈아 움직이기. 
    {
        if (point >= this.transform.position.x)
        {
            Rd.velocity = new Vector2(v, 0f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (point + ran <= this.transform.position.x)
        {
            Rd.velocity = new Vector2(-v, 0f);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (Rd.velocity.x == 0)
        {
            Rd.velocity = new Vector2(v, 0f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void TakeDamage(int damage) //데미지 입는 함수.
    {
        heart -= damage;
        if (heart <= 0)
        {
            Destroy(gameObject);
        }
    }
}
