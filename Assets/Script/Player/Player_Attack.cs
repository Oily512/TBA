using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject gun; //유니티로 부여 - Squid 오브젝트
    public bool attack = false;

    private GameObject Hammer;

    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Hammer = GameObject.FindGameObjectWithTag("Hammer");
        Hammer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //좌클릭 뿅망치
        {
            Hammer.SetActive(true);
            
        }
        else if(Input.GetMouseButtonDown(1)) //우클릭 먹물
        {
            Instantiate(gun, Player.position, Quaternion.identity);
        }
    }
}
