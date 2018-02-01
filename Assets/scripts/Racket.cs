using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {

    public float speed = 150;
    private float h;

    void Update()
    {
        //Debug.Log(currentstate());
    }
    public void move(int direction)
    {

        h = direction;
    }

    void FixedUpdate () {
      //  h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
	}
    public int currentstate()
    {
        return (int)GetComponent<Transform>().position.x / 35;
    }



}
