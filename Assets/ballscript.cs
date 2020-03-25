using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    public int speed = 21;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello Wordl");
        //komponen bola agar memantul
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * speed; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "WallRight" || other.collider.name == "WallLeft")
        {
            GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}
