using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuScript : MonoBehaviour {
    private Animator animator;
    private bool isJumping;
    private bool onTouch;
    private Rigidbody2D rigid;
    private Vector3 toLerp;

    // Use this for initialization
    void Start ()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        onTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onTouch)
        {
            Jump();
            Move();
        }
    }

    private void OnMouseDown()
    {
        onTouch = true;
        animator.SetTrigger("upJump");
    }

    private void Jump()
    {
        toLerp = new Vector3(rigid.transform.position.x, 2, 1);
        if (isJumping && rigid.transform.position.y < 1 - 0.5f)
        {
            rigid.transform.position = Vector3.Lerp(rigid.transform.position, toLerp, 3 * Time.deltaTime);
        }
        else
        {
            isJumping = false;
            rigid.gravityScale = 1;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            isJumping = true;
            rigid.gravityScale = 0;
            rigid.velocity = Vector3.zero;
        }
    }
}
