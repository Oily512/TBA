using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    //���� ����
    public GameObject Water; //ȣ�� ����
    public GameObject Oil;
    public GameObject Player;

    public bool W = false;
    public bool O = false;

    Animator anim;

    private int count = 0;
    private float time = 3f;

    //Oil �ð��� ī��Ʈ
    private float time_O = 0f;
    private int count_O = 0;
    private Vector3 place; //���� ��ġ

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

        if (time >= 6f) //���� ���� ����
        {
            if (count % 3 == 0) //ȣ�� ����
            {
                Hoss();
                time = 0f;
                count += 1;
            }
            else
            {
                O = true;
                time_O += Time.deltaTime;

                if (count_O >= 3) //�� �� �� ������
                {
                    count += 1;
                    count_O = 0;
                    time = 3f;
                    O = false;
                }
                else //���� �� �� �� ��. 
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

        anim.SetBool("W", W); //wave �ð�����
        anim.SetBool("O", O); //strike �ð�����
    }

    void Hoss() //ȣ�� ����
    {
        W = true;
        Water.SetActive(true);
        Water.transform.position = this.transform.position; //���� ��ġ���� ����
    }

    void Tripel(Vector3 place) //�� ���
    {
        Instantiate(Oil, place, Quaternion.identity);
        Debug.Log("���Դ�.");
    }
}
