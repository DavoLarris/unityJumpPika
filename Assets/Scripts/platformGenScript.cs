using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenScript : MonoBehaviour {
    public GameObject prefab1;
    public GameObject prefab2;
    private GameObject freshPlatform;
    private float platformPerSecond = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float limit = platformPerSecond * Time.deltaTime;
        if (Random.value < limit)
        {
            spawnPlatform();
        }
    }

    private void spawnPlatform()
    {
        if (Random.Range(0, 2) == 0)
        {
            freshPlatform = Instantiate(prefab1, transform.position, Quaternion.identity) as GameObject;
            freshPlatform.transform.position = new Vector3(Random.Range(-6.7f, 7), 12, 1);
            freshPlatform.GetComponent<Rigidbody2D>().velocity = Vector3.down * 3;
        } else
        {
            freshPlatform = Instantiate(prefab2, transform.position, Quaternion.identity) as GameObject;
            freshPlatform.transform.position = new Vector3(Random.Range(-6.7f, 7), 12, 1);
            freshPlatform.GetComponent<Rigidbody2D>().velocity = Vector3.down * 3;
        }
        
    }
}
