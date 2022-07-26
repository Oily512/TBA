using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject gun; //����Ƽ�� �ο� - Squid ������Ʈ
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
        if (Input.GetKeyDown(KeyCode.Z)) //��Ŭ�� �и�ġ
        {
            Hammer.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.X)) //��Ŭ�� �Թ�
        {
            if (Player_P.Ssize < 45) //�� �� �ִ� �Թ��� ��������.
            {
                Instantiate(gun, Player_T.position, Quaternion.identity); //�߻�
                S = true;

                if (Player_P.Ssize % 10 < 5) // 20% ����
                {
                    Player_P.Ssize += 1;
                }
                else if (Player_P.Ssize %10 == 5) //�ϳ��� �� ��.
                {
                    Player_P.Ssize += 6;
                }
                else
                {
                    Player_P.Ssize += (10 - (Player_P.Ssize % 10));

                }
            }
            else //�Թ��� �������� ����. size(�� �Թ� ��)�� 45�� ��.
            {
                Debug.Log("�Թ��� ��� �������.");
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
