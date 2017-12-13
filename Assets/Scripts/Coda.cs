using UnityEngine;
using System.Collections;

public class Coda : MonoBehaviour {

	private Rigidbody2D rigid;
	private GameMain gamemain;

	private float speed;
	private Vector2 vec;

    void Start()
    {
		rigid = GetComponent<Rigidbody2D> ();
        gamemain = GameObject.Find("GameMain").GetComponent<GameMain>();

		speed = 20.0f;
		vec.Set (0, 0);
    }

	void Update(){
		if (!gamemain.Play) speed = 0;
		vec.Set(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
	}

	void FixedUpdate () {
		rigid.velocity = vec.normalized * speed;
	}
}
