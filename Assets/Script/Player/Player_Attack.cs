using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject gun; //유니티로 부여 - Squid 오브젝트
    public bool attack = false;
    public int Ssize = 0;

    private bool S = false;
    private float S_T = 0f;

    private Animator anim;
    private GameObject Hammer;
    private GameObject Player;

    Transform Player_T;
    Player Player_P;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Player = GameObject.FindGameObjectWithTag("Player");
        Player_T = Player.GetComponent<Transform>();
        Player_P = Player.GetComponent<Player>();

        Hammer = GameObject.FindGameObjectWithTag("Hammer");
        Hammer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) //좌클릭 뿅망치
        {
            Hammer.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.X)) //우클릭 먹물
        {
            if (Player_P.Ssize < 45) //쏠 수 있는 먹물이 남아있음.
            {
                Instantiate(gun, Player_T.position, Quaternion.identity); //발사
                S = true;

                if (Player_P.Ssize % 10 < 5) // 20% 차감
                {
                    Player_P.Ssize += 1;
                }
                else if (Player_P.Ssize %10 == 5) //하나를 다 씀.
                {
                    Player_P.Ssize += 6;
                }
                else
                {
                    Player_P.Ssize += (10 - (Player_P.Ssize % 10));

                }
            }
            else //먹물이 남아있지 않음. size(쓴 먹물 수)가 45인 것.
            {
                Debug.Log("먹물을 모두 사용했음.");
            }
        }

        if (S)
        {
            S_T += Time.deltaTime;

            if (S_T > 0.25)
            {
                S_T = 0f;
                S = false;
            }
            Debug.Log(S);
        }

        anim.SetBool("H", Hammer.activeSelf);
        anim.SetBool("S", S);

    }
}
