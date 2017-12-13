using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	void Start () {
	}

	void Update () {
		
		if( ( Input.GetButtonDown( "Fire1" ) || Input.GetButtonDown( "Fire2" ) || Input.GetButtonDown( "Jump" ) ) && Time.frameCount > 10)
        {
            SceneManager.LoadScene("main");
        }

		if ( Input.GetKey(KeyCode.Escape) )	Application.Quit();
	}
}
