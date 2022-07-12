using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thorn : MonoBehaviour
{
    const int damage = 1; //이후 수정

    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            Player.TakeDamage(damage);
            Debug.Log("아야!");
        }
    }
}
