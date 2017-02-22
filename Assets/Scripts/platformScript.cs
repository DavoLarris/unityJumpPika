using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platformScript : MonoBehaviour {
    public Text score;
    private int count;
	// Use this for initialization
	void Start () {
        score.text = 0.ToString();
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.down * 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        count += 1;
        score.text = count.ToString();
    }
}
