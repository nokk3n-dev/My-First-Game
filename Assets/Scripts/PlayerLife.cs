using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator deathAnimation;
    private Rigidbody2D player;
    [SerializeField] private AudioSource deathSFX;
    [SerializeField] private AudioSource respawnSFX;
    private void Start()
    {
        deathAnimation = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSFX.Play();
        player.bodyType = RigidbodyType2D.Static;
        deathAnimation.SetTrigger("death");
    }

    private void RestartLevel()
    {
        respawnSFX.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
