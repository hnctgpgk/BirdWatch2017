using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
	public GameObject bird;

	private Text hscoretext;
	private Text scoretext;
	private Text lifetext;

	private Slider kume;

    private AudioSource BGM;
    private AudioClip clip;
    private int i = 0;

	private bool play;
	private float nextbird;

	static private int hscore = 0;
	private int score;
	private int life;

	public bool Play
	{
		get { return play; }
	}

    void Start()
    {
		hscoretext = GameObject.Find ("Canvas/HighScore").GetComponent<Text> ();
		scoretext = GameObject.Find ("Canvas/Score").GetComponent<Text> ();
		lifetext = GameObject.Find("Canvas/Life").GetComponent<Text>();
		kume = GameObject.Find ("Canvas/Slider").GetComponent<Slider>();

        BGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        clip = BGM.clip;
        BGM.Play();

		play = true;
		nextbird = 1.0f;

		hscoretext.text = hscore.ToString ().PadLeft (6, '0');

		score = 0;
		scoretext.text = score.ToString ().PadLeft (6, '0');

		life = 5;
		lifetext.text = life.ToString();

		GameObject.Find ("Canvas/Gameover").GetComponent<Text> ().enabled = false;

		StartCoroutine ("BirdEmitter");
   }

	IEnumerator BirdEmitter(){
		while (true && play ) {
			yield return new WaitForSeconds (nextbird);
			Vector2 postion = bird.transform.position;
			postion.x = Random.Range (-5f, 5f);
			Instantiate (bird, postion, bird.transform.rotation);
		}
	}
		
	void Update ()
	{
		if ( Input.GetKey(KeyCode.Escape) )	Application.Quit();
    }

	public void IncScore ()
	{
		score++;
		scoretext.text = score.ToString ().PadLeft (6, '0');

		if (score > hscore) {
			hscore = score;
			hscoretext.text = hscore.ToString ().PadLeft (6, '0');
		}

		nextbird = Mathf.Max (0.01f, 1.0f - score / 100f);
	}

	public void DeclLife()
	{
		if (life > 0){			
			life--;
			kume.value = life;
			lifetext.text = life.ToString();
			if (life == 0) StartCoroutine ("Gameover");
		}
	}

	IEnumerator Gameover(){
		play = false;
		GameObject.Find ("Canvas/Gameover").GetComponent<Text> ().enabled = true;
		yield return new WaitForSeconds( 3.0f );
		SceneManager.LoadScene ("title");
	}
}
