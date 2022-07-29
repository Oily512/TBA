using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{
    //���� ����
    public GameObject Won; //ȣ�� ����
    public GameObject Tripel;
    public GameObject Player;

    public bool W = false;
    public bool T = false;

    Animator anim;

    private int count = 0;
    private float time = 1.5f;

    //Oil �ð��� ī��Ʈ
    private float time_T = 0f;
    private int count_T = 0;
    private Vector3 place; //���� ��ġ

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

        if (time >= 3f) //���� ���� ����
        {
            if (count % 3 == 0) //ū�� �� �� ����
            {
                WGun();
                Debug.Log("������ ��");
                time = 0f;
                count += 1;
            }
            else
            {
                T = true;
                time_T += Time.deltaTime;

                if (count_T >= 3) //�� �� �� ������
                {
                    count += 1;
                    count_T = 0;
                    time = 1.5f;
                    T = false;
                }
                else //���� �� �� �� ��. 
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

        anim.SetBool("W", W); //wave �ð�����
        anim.SetBool("T", T); //strike �ð�����
    }

    void WGun() //ū �� ����
    {
        W = true;
        Won.SetActive(true);
        Won.transform.position = this.transform.position; //���� ��ġ���� ����
        Debug.Log("���۵� ��");
    }

    void TGun(Vector3 place) //���� �� ����
    {
        Instantiate(Tripel, place, Quaternion.identity);
        Debug.Log("���Դ�.");
    }
}
