using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float time = -3f;
    Player P1;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.1f)
        {
            this.transform.Translate(new Vector3(0.4f, 0f, 0f));
            time = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            P1 = other.GetComponent<Player>();
            P1.TakeDamage(10000);
            Debug.Log("ав╬З╢ы");
        }
    }
}
