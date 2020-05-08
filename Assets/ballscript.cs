using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    //public int speed = 21;

    //object reference
    public Rigidbody2D objek1;

    public Animator anim;

    public GameObject masterScript;
    
    public AudioSource hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        //komponen bola agar bergerak
        //GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * speed; 
        //objek1.velocity = new Vector2(-1, -1) * speed;

        //karakteristik objek reference
        objek1.GetComponent<Transform>().position = Vector2.zero;

        int speed = Random.Range(20, 26);
        int x = Random.Range(0, 2) * 2 - 1; //maka range yg dihasilkan antara -1 dan 1
        int y = Random.Range(0, 2) * 2 - 1;
        objek1.velocity = new Vector2(x,y)*speed;
        anim.SetBool("IsMove", true);
    }

    //arah animasi api mengikuti pergerakan bola, karena bola merupakan parent api
    //yg diubah di component -> transform bagian scale
    void FixedUpdate()
    {
       if(objek1.velocity.x > 0)
        {
            objek1.GetComponent<Transform>().localScale = new Vector3(1, 1, 1); //supaya bola bergerak ke kanan
        }
        else
        {
            objek1.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1); //supaya bola bergerak ke kiri
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "WallRight" || other.collider.name == "WallLeft")
        {
            masterScript.GetComponent<ScoringScript>().UpdateScoring(other.collider.name);
            //menjeda bola setelah terkena tembok
            StartCoroutine(jeda());
        }
        //audio bola tersentuh
        if(other.collider.tag == "Player")
        {
            hitEffect.Play();
        }
    }

    IEnumerator jeda()
    {
        int speed = Random.Range(20, 26);
        int x = Random.Range(0, 2) * 2 - 1; 
        int y = Random.Range(0, 2) * 2 - 1;

        objek1.velocity = Vector2.zero;
        anim.SetBool("IsMove", false);
        objek1.GetComponent<Transform>().position = Vector2.zero;
        yield return new WaitForSeconds(1);
        objek1.velocity = new Vector2(x,y) * speed;
        anim.SetBool("IsMove", true);
    }
}
