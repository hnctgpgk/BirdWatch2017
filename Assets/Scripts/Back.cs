using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

	public GameObject star;

	void Start () {
		StartCoroutine ("StarEmitter");
	}

	IEnumerator StarEmitter(){
		while (true) {
			Quaternion rotation = Quaternion.Euler (0f, 0f, Random.Range (0, 360)); 
			Instantiate (star, star.transform.position, rotation);
			yield return new WaitForSeconds (0.1f);
		}
	}
}
