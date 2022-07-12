using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject gun; //����Ƽ�� �ο� - Squid ������Ʈ
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
        if (Input.GetMouseButtonDown(0)) //��Ŭ�� �и�ġ
        {
            Hammer.SetActive(true);
            
        }
        else if(Input.GetMouseButtonDown(1)) //��Ŭ�� �Թ�
        {
            Instantiate(gun, Player.position, Quaternion.identity);
        }
    }
}
