using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Squid : MonoBehaviour
{
    private int size;

    private RectTransform rt;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        TransD();
    }

    void TransD()
    {
        size = player.Ssize; //���� ���� ��������

        //�Թ� �� ���� ���, �׸���
        size =  10 + (size / 10) * 42 + size % 10 * 7;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
    }
}
