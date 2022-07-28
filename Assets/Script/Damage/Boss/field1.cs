
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field1 : MonoBehaviour
{
    public GameObject Boss1; 

    Player player;

    private int damage = 10;
    private float time = 0f;

    Boss1 Boss;

    // Start is called before the first frame update
    void Start()
    {
        Boss = Boss1.GetComponent<Boss1>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 1.2f)
        {
            Boss.A = false;
            gameObject.SetActive(false);
            time = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }
}
