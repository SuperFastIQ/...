using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private AudioSource _dyingSFX;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Traps"))
        {
            Die();//Get Conflict via master branch?
        }
    }

    private void Die()
    {
        _dyingSFX.Play();//branch change 1
        _animator.SetTrigger("Die");
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
