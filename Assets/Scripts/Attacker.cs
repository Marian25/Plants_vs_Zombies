using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [SerializeField] [Range(-1f, 1.5f)] float walkSpeed = .5f;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " trigger enter");
    }
}
