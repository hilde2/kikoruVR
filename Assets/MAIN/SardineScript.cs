using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineScript : MonoBehaviour {
    public Transform[] target;
    public float speed;

    private int current;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

            // Make the sardine look at the right direction
            Vector3 direction = (target[current].position - transform.position).normalized;
            Quaternion look = Quaternion.LookRotation(direction);
            transform.rotation = look;  
        }
        else { current = (current + 1) % target.Length; }
    }

}
