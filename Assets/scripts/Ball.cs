using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    public float speed = 100.0f;
    public int direction = 0; // 0 down - 1 up
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position,collision.transform.position,collision.collider.bounds.size.x);

            
            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
    public int[] currentstate()
    {
        return new int[] { (int)GetComponent<Transform>().position.x/35, (int)GetComponent<Transform>().position.y/10 };
    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos,float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    // Update is called once per frame
    void Update () {
        //Reset ball
        if (GetComponent<Transform>().position.y < 0)
        {
            GetComponent<Transform>().position = new Vector2(130,85);
        }
       
        //Debug.Log(currentstate()[0]+ " " + currentstate()[1]);
	}
}
