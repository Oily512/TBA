using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    //보스 설정
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

        anim.SetBool("W", W); //wave 시간동안
        anim.SetBool("A", A); //strike 시간동안
    }

    void wave() //지면에 좌라락
    {
        W = true;
        effect.SetActive(true);
        effect.transform.position = this.transform.position + new Vector3(0f, -3.8f, 0f); //보스 위치에서 시작
    }

    void strike() //근접공격. 내려치기
    {
        A = true;
        field.SetActive(true);
    }
}
