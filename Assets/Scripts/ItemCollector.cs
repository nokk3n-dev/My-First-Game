using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int strawberryCount = 0;

    [SerializeField] private Text strawberriesText;

    [SerializeField] private AudioSource collectionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);
            collectionSound.Play();
            strawberryCount++;
            strawberriesText.text = "Strawberries: " + strawberryCount;
        }
    }
}
