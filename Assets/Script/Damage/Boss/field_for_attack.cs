
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_for_attack : MonoBehaviour
{
    Player Hrt;

    private int damage = 10;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1.2f)
        {
            time = 0f;
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Hrt = other.GetComponent<Player>();
            Hrt.TakeDamage(damage);
        }
    }
}
