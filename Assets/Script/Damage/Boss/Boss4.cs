using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{
    //보스 설정
    public GameObject Won; //호스 공격
    public GameObject Tripel;
    public GameObject Player;

    public bool W = false;
    public bool T = false;

    Animator anim;

    private int count = 0;
    private float time = 1.5f;

    //Oil 시간과 카운트
    private float time_T = 0f;
    private int count_T = 0;
    private Vector3 place; //생성 위치

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Won.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3f) //다음 공격 패턴
        {
            if (count % 3 == 0) //큰거 한 번 공격
            {
                WGun();
                Debug.Log("공격은 해");
                time = 0f;
                count += 1;
            }
            else
            {
                T = true;
                time_T += Time.deltaTime;

                if (count_T >= 3) //세 번 다 쐈으면
                {
                    count += 1;
                    count_T = 0;
                    time = 1.5f;
                    T = false;
                }
                else //아직 세 번 안 쏨. 
                {
                    if (time_T > 0.3f)
                    {
                        place = new Vector3(gameObject.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);
                        TGun(place);
                        time_T = 0f;
                        count_T += 1;
                    }
                }
            }
        }

        anim.SetBool("W", W); //wave 시간동안
        anim.SetBool("T", T); //strike 시간동안
    }

    void WGun() //큰 총 공격
    {
        W = true;
        Won.SetActive(true);
        Won.transform.position = this.transform.position; //보스 위치에서 시작
        Debug.Log("시작도 해");
    }

    void TGun(Vector3 place) //작은 총 공격
    {
        Instantiate(Tripel, place, Quaternion.identity);
        Debug.Log("들어왔다.");
    }
}
