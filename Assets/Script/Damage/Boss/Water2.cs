using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water2 : MonoBehaviour
{
    public GameObject Boss2;

    Boss2 Boss;
    Player player;

    private int damage = 10;
    private float time = 0.3f;
    private float size = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Boss = Boss2.GetComponent<Boss2>(); //스킬쓰는 보스의 클래스 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 0.13f)
        {
            this.transform.localScale = new Vector3(size, 2f, 0f);
            size += 0.4f;
            time = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle") //벽이랑 충돌하면 비활성화
        {
            //재활용을 위한 초기화
            this.transform.localScale = new Vector3(1f, 2f, 0f);
            size = 1f;

            //비활성화
            Boss.W = false;
            gameObject.SetActive(false);
        }

        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }
}
