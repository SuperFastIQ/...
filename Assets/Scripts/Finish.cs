using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private AudioSource _finishSound;

    private bool _finishedLevel = false;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !_finishedLevel)
        {
            _finishSound.Play();
            _finishedLevel = true;
            Invoke("CompleteLevel", 2f);
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
