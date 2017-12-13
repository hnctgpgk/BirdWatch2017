using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    private GameMain gamemain;

    private AudioSource sound01;

    void Start()
    {
        gamemain = GameObject.Find("GameMain").GetComponent<GameMain>();

        float speed = Random.Range(0.5f, 10.0f);
        float x = Random.Range(-0.2f, 0.2f);
        float y = -1.0f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y).normalized * speed;

        sound01 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gamemain.Play) Stopbird();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "bottom")
        {
            gamemain.DeclLife();
            Stopbird();
            GetComponent<Animator>().SetBool("IsGrounded", true);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "coda")
        {
            gamemain.IncScore();
            Stopbird();
            GetComponent<Animator>().SetBool("IsDie", true);
            Destroy(gameObject, 1.0f);
            sound01.PlayOneShot(sound01.clip);
        }
    }

    private void Stopbird()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}