using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator anim; 

    private float dis_P; //사거리
    private float time = 0.7f; //공격 타이밍. 바로 공격하기 위함. 

    public GameObject Sight; //에디터에서 매치
    public GameObject Player; //에디터에서 매치
    public GameObject Trash; //에디터에서 매치

    Sight sight;
    Rigidbody2D Place;
    Heart Hrt;

    // Start is called before the first frame update
    void Start()
    {
        Place = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        Hrt = GetComponent<Heart>();
        sight = Sight.GetComponent<Sight>(); //시야 오브젝트의 클래스를 가져옴.

        Player = GameObject.FindGameObjectWithTag("Player");

        Hrt.v = Random.Range(3, 6); //속력 랜덤
        dis_P = Random.Range(4, 8); //사거리 랜덤
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
            Hrt.move(); //평소의 움직임. 
        }

        anim.SetBool("A", sight.meet); //사거리 안에 있으면 공격 모션. 
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
