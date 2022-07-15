using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Game;
    public GameObject Option; //����â

    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.FindGameObjectWithTag("GameController"); //�������� ���� ��
        Option = GameObject.FindGameObjectWithTag("Menu"); //����â

        Option.SetActive(false);
        Game.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�������� ���� ��
        {
            if (!Game.activeSelf)
            {
                Game.SetActive(true);
            }
            else
            {
                Game.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) //����â
        {
            if (!Option.activeSelf)
            {
                Option.SetActive(true);
            }
            else
            {
                Option.SetActive(false);
            }
        }
    }
}
