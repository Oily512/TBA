using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int heart = 1;
    private float v = 0f;
    private float point;
    private float dis_P;
    private float time = 0.7f;

    public float ran = 8f;

    public GameObject Sight;
    public GameObject Player;

    public GameObject Trash;

    Sight sight;
    Rigidbody2D Place;

    // Start is called before the first frame update
    void Start()
    {
        v = Random.Range(3, 6);
        dis_P = Random.Range(4, 8);

        Place = GetComponent<Rigidbody2D>();
        sight = Sight.GetComponent<Sight>();

        Player = GameObject.FindGameObjectWithTag("Player");
        point = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(sight.meet == true) //오류나면 meet 변수 따로 쓰는 걸로 수정
        {
            Debug.Log("Player 공격");
            attack();

            time += Time.deltaTime;

            if (time >= 1.0f)
            {
                Instantiate(Trash, gameObject.transform.position, Quaternion.identity);
                time = 0f;
            }
        }
        else if (sight.meet == false)
        {
            move();
        }
    }

    private void move()
    {
        if (point >= Place.transform.position.x)
        {
            Place.velocity = new Vector2(v, 0f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (point + ran <= Place.transform.position.x)
        {
            Place.velocity = new Vector2(-v, 0f);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void attack()
    {
        //Player 바라보기
        if (0 < Player.transform.position.x - this.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (0 > Player.transform.position.x - this.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //사거리 밖이면 쫓아가기
        if (-dis_P > Player.transform.position.x - this.transform.position.x)
        {
            Place.velocity = new Vector2(-v, 0f);
        }    
        else if (dis_P < Player.transform.position.x - this.transform.position.x)
        {
            Place.velocity = new Vector2(v, 0f);
        }
        else
        {
            Place.velocity = new Vector2(0f, 0f);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("몬스터가 맞았다");
        heart -= damage;
        if(heart <= 0)
        {
            Destroy(gameObject);
        }
    }
}
