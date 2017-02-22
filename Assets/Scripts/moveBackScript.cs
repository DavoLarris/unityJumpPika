using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackScript : MonoBehaviour {
    private float scrollSpeed = 5;
    private Rigidbody2D rigid;

    private Vector3 startPosition;

    // Use this for initialization
    void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
        startPosition = rigid.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 20);
        rigid.transform.position = startPosition + Vector3.down * newPosition;
    }
}
