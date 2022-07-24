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
        size = player.Ssize; //길이 정보 가져오기

        //먹물 바 길이 계산, 그리기
        size =  10 + (size / 10) * 42 + size % 10 * 7;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
    }
}
