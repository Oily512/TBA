using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator anim; 

    private float dis_P; //��Ÿ�
    private float time = 0.7f; //���� Ÿ�̹�. �ٷ� �����ϱ� ����. 

    public GameObject Sight; //�����Ϳ��� ��ġ
    public GameObject Player; //�����Ϳ��� ��ġ
    public GameObject Trash; //�����Ϳ��� ��ġ

    Sight sight;
    Rigidbody2D Place;
    Heart Hrt;

    // Start is called before the first frame update
    void Start()
    {
        Place = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        Hrt = GetComponent<Heart>();
        sight = Sight.GetComponent<Sight>(); //�þ� ������Ʈ�� Ŭ������ ������.

        Player = GameObject.FindGameObjectWithTag("Player");

        Hrt.v = Random.Range(3, 6); //�ӷ� ����
        dis_P = Random.Range(4, 8); //��Ÿ� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(sight.meet == true) //��Ÿ� ������ �������� ���� ��ƾ.
        {
            Debug.Log("Player ����");
            attack(); //������ ���� ������. 

            time += Time.deltaTime;

            if (time >= 1.0f) //�ð��Ǹ� ����
            {
                Instantiate(Trash, gameObject.transform.position, Quaternion.identity);
                time = 0f; //�ð� �ʱ�ȭ
            }
        }
        else if (sight.meet == false) //��Ÿ� �ȿ� ����.
        {
            Hrt.move(); //����� ������. 
        }

        anim.SetBool("A", sight.meet); //��Ÿ� �ȿ� ������ ���� ���. 
    }

    private void attack() //������ ���� ������. 
    {
        //Player �ٶ󺸱�
        if (0 < Player.transform.position.x - this.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (0 > Player.transform.position.x - this.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //��Ÿ� ���̸� �Ѿư���
        if (-dis_P > Player.transform.position.x - this.transform.position.x)
        {
            Place.velocity = new Vector2(-Hrt.v, 0f);
        }    
        else if (dis_P < Player.transform.position.x - this.transform.position.x)
        {
            Place.velocity = new Vector2(Hrt.v, 0f);
        }
        else
        {
            Place.velocity = new Vector2(0f, 0f);
        }
    }
}
