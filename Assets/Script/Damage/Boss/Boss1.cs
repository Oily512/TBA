using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    //���� ����
    public GameObject effect; //wave
    public GameObject field;

    public bool W = false;
    public bool A = false;

    Animator anim;

    private int count = 0;
    private float time = 3f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        effect.SetActive(false);
        field.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        Debug.Log(W);
        Debug.Log(A);

        if (time  >= 6f)
        {
            if (count%3 == 0)
            {
                wave();
                time = 0f;
            }
            else
            {
                strike();
                time = 3f;
            }

            count += 1;
        }

        anim.SetBool("W", W); //wave �ð�����
        anim.SetBool("A", A); //strike �ð�����
    }

    void wave() //���鿡 �¶��
    {
        W = true;
        effect.SetActive(true);
        effect.transform.position = this.transform.position + new Vector3(0f, -3.8f, 0f); //���� ��ġ���� ����
    }

    void strike() //��������. ����ġ��
    {
        A = true;
        field.SetActive(true);
    }
}
