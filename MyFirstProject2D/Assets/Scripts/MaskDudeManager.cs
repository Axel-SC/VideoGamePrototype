using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDudeManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
        }
       
    }
}
