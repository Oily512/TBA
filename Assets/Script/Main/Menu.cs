using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Game;
    public GameObject Option;

    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.FindGameObjectWithTag(""); //�������� ���� ��
        Option = GameObject.FindGameObjectWithTag(""); //����â
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�������� ���� ��
        {

        }
        else if (Input.GetKeyDown(KeyCode.Escape)) //����â
        {

        }
    }
}
