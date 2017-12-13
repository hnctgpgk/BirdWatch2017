using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	
	void Start () {
		float speed = Random.Range (1.0f, 10.0f);
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
		Destroy (gameObject, 1.5f);
    }

}
