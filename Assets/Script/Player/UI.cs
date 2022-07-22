using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    //1. Player의 heart를 받아와야 함. 
    //2. 그걸로 local scale을 바꿔야 함. 
    //2-1 최대값이 얼마인지 알아야 하고
    //local scale은 최대값/100 *heart
    private Player player;
    private float size;
    private RectTransform rt;

    public GameObject P;

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
        size = (player.heart / 100) * 240;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
    }
}
