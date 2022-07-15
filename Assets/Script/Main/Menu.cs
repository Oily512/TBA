using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Game;
    public GameObject Option; //설정창

    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.FindGameObjectWithTag("GameController"); //스테이지 진입 탭
        Option = GameObject.FindGameObjectWithTag("Menu"); //설정창

        Option.SetActive(false);
        Game.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //스테이지 진입 탭
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
        else if (Input.GetKeyDown(KeyCode.Escape)) //설정창
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
