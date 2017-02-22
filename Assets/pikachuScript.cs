using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuScript : MonoBehaviour {
    private Animator animator;
    private Rigidbody2D rigid;
    private float speed = 20;
    private bool isJumping;

    // Use this for initialization
    void Start () {
        isJumping = false;
        rigid = rigid = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () { //IsGrounded?
        Move();
        if (!isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.Play("jumpAnim");
                isJumping = true;
                rigid.velocity = Vector2.up * speed;
                rigid.gravityScale = 2;
            }
        }
        
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigid.transform.eulerAngles = new Vector2(0, 180);
            rigid.transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.transform.eulerAngles = new Vector2(0, 0);
            rigid.transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            animator.Play("idleAnim");   
            isJumping = false;
        }
    }
}
