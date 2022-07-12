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

        /*dir = Monster.rotation.eulerAngles;*/ //���� ���� �����ϰ� Ǯ��.
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
        } */ //���� ���� �����ϰ� Ǯ��.

        if (T >= 2f) //��Ÿ� ����.
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("���� ������ ������");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}