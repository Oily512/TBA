using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HP : MonoBehaviour
{
    //1. Player의 heart를 받아와야 함. 
    private Player player;
    private float size;
    private RectTransform rt;

    public GameObject P; //오브젝트 에디터에서 연결

    // Start is called before the first frame update
    void Start()
    {
        player = P.GetComponent<Player>();
        rt = gameObject.GetComponent<RectTransform>();

        size = player.heart;
    }

    // Update is called once per frame
    void Update()
    {
        size = (player.heart / 100) * 227;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
    }
}
