using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text _melonCounterText;

    [SerializeField] private AudioSource _collectingSFX;

    private int _melonCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MelonItem"))
        {
            Destroy(collision.gameObject);
            _melonCount++;
            _collectingSFX.Play();
            _melonCounterText.text = "Melons: " + _melonCount;
        }
    }
}
