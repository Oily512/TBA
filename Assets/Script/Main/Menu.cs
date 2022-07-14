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
        Game = GameObject.FindGameObjectWithTag(""); //스테이지 진입 탭
        Option = GameObject.FindGameObjectWithTag(""); //설정창
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //스테이지 진입 탭
        {

        }
        else if (Input.GetKeyDown(KeyCode.Escape)) //설정창
        {

        }
    }
}
