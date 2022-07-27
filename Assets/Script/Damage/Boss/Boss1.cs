using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    //보스 설정
    public int heart;
    public GameObject Trash; //wave
    public GameObject field;

    private Vector3 spon;

    // Start is called before the first frame update
    void Start()
    {
        field.SetActive(false);

        spon = new Vector3(this.transform.position.x, this.transform.position.y - 2f, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Trash, spon, Quaternion.identity);
    }

    void wave() //지면에 좌라락
    {
        Instantiate(Trash, spon, Quaternion.identity);
    }

    void strike() //근접공격. 내려치기
    {
        field.SetActive(true);
    }

    public void TakeDamage(int damage) //데미지 입는 함수.
    {
        heart -= damage;
        if (heart <= 0)
        {
            Destroy(gameObject);
        }
    }
}
