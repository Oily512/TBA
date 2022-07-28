using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP_Boss : MonoBehaviour
{
    //1. Boss�� heart�� �޾ƿ;� ��. 
    public GameObject Boss; //������Ʈ �����Ϳ��� ����

    private float whole;
    private float size; 
    private RectTransform rt;
    private Heart hrt;

    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        hrt = Boss.GetComponent<Heart>();

        whole = hrt.heart;
    }

    // Update is called once per frame
    void Update()
    {
        size = (hrt.heart / whole) * 270;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);

        if (size <= 0)
        {
            SceneManager.LoadScene(3); //���� ���� ��
        }
    }
}
