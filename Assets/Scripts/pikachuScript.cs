using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuScript : MonoBehaviour {
    private Animator animator;
    private int speed = 20;
    public KeyCode keySpace, aKey, dKey, rightKey, leftKey;
    private bool isJumping;

    // Use this for initialization
    void Start () {
        this.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.identity; //estabilizacion
        this.GetComponent<Rigidbody2D>().gravityScale = 6;
        isJumping = false;
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.identity; //estabilizacion
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            animator.SetTrigger("onLeft");
        } 
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            animator.SetTrigger("onRight");
        }
        if (Input.GetKeyDown(keySpace))
        {
            if (!isJumping)
            {
                Debug.Log("Space was pressed");
                this.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                isJumping = true;
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetTrigger("relax");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isJumping = false;
        }
    }
}
