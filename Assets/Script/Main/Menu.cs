using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Game;
    public GameObject Game2;
    public GameObject Option; //����â
    public GameObject Control; //��ư ����â

    // Start is called before the first frame update
    void Start()
    {
        Option.SetActive(false);
        Game.SetActive(false);
        Game2.SetActive(false);
        Control.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�������� ���� ��
        {
            if (Game.activeSelf || Game2.activeSelf)
            {
                Game.SetActive(false);
                Game2.SetActive(false);
            }
            else
            {
                Game.SetActive(true);
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

    public void Triangle()
    {
        Game.SetActive(false);
        Game2.SetActive(true);
    }

    public void Triangle2()
    {
        Game.SetActive(true);
        Game2.SetActive(false);
    }
}
