using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuScript : MonoBehaviour {
    private Animator animator;
    private int speedJump = 20, speedRun = 10;
    public KeyCode keySpace, aKey, dKey, rightKey, leftKey;
    private bool isJumping;
    private Rigidbody2D rigid;

    // Use this for initialization
    void Start ()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        this.rigid.transform.rotation = Quaternion.identity; //estabilizacion
        this.rigid.gravityScale = 6;
        isJumping = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigid.velocity = movement * speedRun;

        if (rigid.velocity.x > 0)
        {
            rigid.transform.rotation = Quaternion.identity; //estabilizacion
            animator.SetTrigger("onRight");
        } else if(rigid.velocity.x < 0)
        {
            rigid.transform.rotation = Quaternion.identity; //estabilizacion
            animator.SetTrigger("onLeft");
        } else
        {
            rigid.transform.rotation = Quaternion.identity; //estabilizacion
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
