using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator anim; 

    private int heart = 10; //목숨
    private float v = 0f; //속력
    private float point; //현재 x좌표
    private float dis_P; //사거리
    private float time = 0.7f; //공격 타이밍. 바로 공격하기 위함. 

    public float ran = 8f; //이동 범위
    public int damage = 3; //공격력

    public GameObject Sight; //에디터에서 매치
    public GameObject Player; //에디터에서 매치
    public GameObject Trash; //에디터에서 매치

    Sight sight;
    Rigidbody2D Place;

    // Start is called before the first frame update
    void Start()
    {
        v = Random.Range(3, 6); //속력 랜덤
        dis_P = Random.Range(4, 8); //사거리 랜덤

        Place = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>(); 
        sight = Sight.GetComponent<Sight>(); //시야 오브젝트의 클래스를 가져옴.

        Player = GameObject.FindGameObjectWithTag("Player");
        point = transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        if(sight.meet == true) //사거리 안으로 들어왔으면 공격 루틴.
        {
            Debug.Log("Player 공격");
            attack(); //공격할 때의 움직임. 

            time += Time.deltaTime;

            if (time >= 1.0f) //시간되면 공격
            {
                Instantiate(Trash, gameObject.transform.position, Quaternion.identity);
                time = 0f; //시간 초기화
            }
        }
        else if (sight.meet == false) //사거리 안에 없음.
        {
            move(); //평소의 움직임. 
        }

        anim.SetBool("A", sight.meet); //사거리 안에 있으면 공격 모션. 
    }

    private void move() //좌우로 번갈아 움직이기. 
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
        else if (Place.velocity.x == 0)
        {
            Place.velocity = new Vector2(v, 0f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void attack() //공격할 때의 움직임. 
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

    public void TakeDamage(int damage) //데미지 입는 함수.
    {
        heart -= damage;
        if(heart <= 0)
        {
            Destroy(gameObject);
        }
    }
}
