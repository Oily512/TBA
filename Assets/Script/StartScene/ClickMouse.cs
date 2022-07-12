using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickMouse : MonoBehaviour
{
    public GameObject Text_Old;
    public GameObject Buttons;
    public GameObject Panel;

    public string TagName = "GameController";
    public string TagNameF = "Finish"; 

    // Start is called before the first frame update
    void Start()
    {
        Text_Old = GameObject.FindGameObjectWithTag(TagNameF);
        Buttons = GameObject.FindGameObjectWithTag(TagName);
        Panel = GameObject.FindGameObjectWithTag("Option");

        Buttons.SetActive(false);
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitOption();
    }

    public void StartGame()
    {
            Destroy(Text_Old);
            Buttons.SetActive(true);
            Text_Old.SetActive(false);
    }

    public void StartOption()
    {
            Buttons.SetActive(false);
            Panel.SetActive(true);
    }

    public void ExitOption()
    {
        Buttons.SetActive(true);
        Panel.SetActive(false);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
