using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewsPaper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartStage1()
    {
        SceneManager.LoadScene(4);
    }

    public void StartStage2()
    {
        SceneManager.LoadScene(6);
    }

    public void StartStage3()
    {
        SceneManager.LoadScene(8);
    }

    public void StartStage4()
    {
        SceneManager.LoadScene(10);
    }
}
