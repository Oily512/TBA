using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    //보스 설정
    public GameObject Water; //호스 공격
    public GameObject Oil;
    public GameObject Player;

    public bool W = false;
    public bool O = false;

    Animator anim;

    private int count = 0;
    private float time = 3f;

    //Oil 시간과 카운트
    private float time_O = 0f;
    private int count_O = 0;
    private Vector3 place; //생성 위치

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Water.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 6f) //다음 공격 패턴
        {
            if (count % 3 == 0) //호스 공격
            {
                Hoss();
                time = 0f;
                count += 1;
            }
            else
            {
                O = true;
                time_O += Time.deltaTime;

                if (count_O >= 3) //세 번 다 쐈으면
                {
                    count += 1;
                    count_O = 0;
                    time = 3f;
                    O = false;
                }
                else //아직 세 번 안 쏨. 
                {
                    if (time_O > 0.3f)
                    {
                         place = new Vector3(gameObject.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);
                         Tripel(place);
                         time_O = 0f;
                         count_O += 1;
                    }
                }
            }
        }

        anim.SetBool("W", W); //wave 시간동안
        anim.SetBool("O", O); //strike 시간동안
    }

    void Hoss() //호스 공격
    {
        W = true;
        Water.SetActive(true);
        Water.transform.position = this.transform.position; //보스 위치에서 시작
    }

    void Tripel(Vector3 place) //세 방울
    {
        Instantiate(Oil, place, Quaternion.identity);
        Debug.Log("들어왔다.");
    }
}
