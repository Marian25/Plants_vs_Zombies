using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed = .5f;
    private GameObject currentTarget;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " trigger enter");
    }

    public void SetCurrentSpped(float speed) {
        currentSpeed = speed;
    }

    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget(float damage) {
        Debug.Log(name + " caused damage: " + damage);
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }

}
