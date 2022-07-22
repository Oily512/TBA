using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D PlayerMove;
    private Animator anim;

    private bool W; //Hike �ִϸ��̼� ����
    private bool touch; //Obstacle���� �浹 ����

    public float speed;
    public float Direction;
    public float heart = 100f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move To Front/Back
        Direction = Input.GetAxis("Horizontal");

        if (Direction > 0) //�¿� �̵��� ���� ĳ���� ȸ��
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (Direction < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);

        PlayerMove.velocity = new Vector2(Direction * speed, PlayerMove.velocity.y);

        Jump_Move();
        hike();
        anim.SetBool("W", W);
        anim.SetBool("M", Direction != 0);
        anim.SetBool("J", PlayerMove.velocity.y > 0);
    }

    private void Jump_Move()
    {
        //Jump
        if ((touch) && (Input.GetKeyDown(KeyCode.Space) && (PlayerMove.velocity.y < 5f)))
        {
            PlayerMove.AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse);
        }    
        else if ((Input.GetKeyDown(KeyCode.Space)) && PlayerMove.velocity.y == 0)
        {
            PlayerMove.AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
        }
    }

    private void hike()
    {
        if ((touch) && ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))) //�� Ÿ��
        {
            W = true;
            transform.Translate(new Vector3(0f, 0.03f, 0f)); 
        }
        else
            W = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Obstacle") //�Ϲ� ��ֹ��� �浹
        {
            touch = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            touch = false;
        }
    }

    public void TakeDamage(int Damage)
    {
        heart = heart - Damage;
        Debug.Log("���Ŀ�");
        if (heart <= 0)
        {
            Debug.Log("����"); //�ڵ� �߰�
        }
    }
}
