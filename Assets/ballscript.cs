using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    public int speed = 21;

    //object reference
    public Rigidbody2D objek1;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello Wordl");
        //komponen bola agar memantul
        //GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * speed; 

        //karakteristik objek reference
        objek1.velocity = new Vector2(-1, -1) * speed;

        anim.SetBool("IsMove", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(objek1.velocity.x > 0)
        {
            objek1.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
        else
        {
            objek1.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "WallRight" || other.collider.name == "WallLeft")
        {
            GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}
