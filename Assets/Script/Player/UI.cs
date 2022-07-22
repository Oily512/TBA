using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    //1. Player�� heart�� �޾ƿ;� ��. 
    //2. �װɷ� local scale�� �ٲ�� ��. 
    //2-1 �ִ밪�� ������ �˾ƾ� �ϰ�
    //local scale�� �ִ밪/100 *heart
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
