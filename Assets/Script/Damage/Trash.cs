using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 dir;
    private float T = 0f;

    Transform Monster;
    Rigidbody2D rd;

    // Start is called before the first frame update
    void Start()
    {
        Monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Transform>();
        rd = GetComponent<Rigidbody2D>();

        /*dir = Monster.rotation.eulerAngles;*/ //몬스터 방향 설정하고 풀기.
    }

    // Update is called once per frame
    void Update()
    {
        T += Time.deltaTime;

        /* if (dir[1] <= 0)
        {
            rd.velocity = new Vector2(speed, 0f);
        }
        else if (dir[1] > 0)
        {
            rd.velocity = new Vector2(-speed, 0f);
        } */ //몬스터 방향 설정하고 풀기.

        if (T >= 2f) //사거리 설정.
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("공격 데미지 입히기");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}