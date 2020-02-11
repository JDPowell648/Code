using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    [SerializeField] AudioSource enginestart;
    [SerializeField] AudioSource enginesloop;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= 1.5 && !enginesloop.isPlaying)
        {
            enginesloop.Play();
        }
    }
}
