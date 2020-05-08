using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KananMovement : MonoBehaviour
{
    public int speed = 35;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //pergerakan raket
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed; //atribut vector2(posisi x, posisi y) 
                                                                              //artinya raket hanya bergerak di sumbu y
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * speed;
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0) * speed;
        }
    }
}
