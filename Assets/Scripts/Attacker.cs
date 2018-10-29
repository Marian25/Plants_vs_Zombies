using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [SerializeField] [Range(-1f, 1.5f)] float currentSpeed = .5f;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
	}
	
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

    public void StrikeCurrentTarget(float damage) {
        Debug.Log(name + " caused damage: " + damage);
    }


}
