using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolkaTime : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] GameObject Polka42;
    [SerializeField] GameObject M4A1L;
    [SerializeField] GameObject CromwellT;
    private GameObject Follow;
    [SerializeField] AudioSource rus;
    [SerializeField] AudioSource polkaaa;
    [SerializeField] AudioSource AmericaPl;
    [SerializeField] AudioSource Britain;
    private bool polkatimee;
    // Use this for initialization

    void Start()
    {
        Follow = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("NoVehicle"))
        {
            Time.timeScale = 0;
        }
        else if (EscapeMenu.paused == false)
        {
            Time.timeScale = 1;
        }
        /* if (Follow.transform.GetChild(0).CompareTag("American"))
        {
            rus.Stop();
            Britain.Stop();
            polkaaa.Stop();
            AmericaPl.Play();
        }
        if (Follow.transform.GetChild(0).CompareTag("Russian"))
        {
            rus.Play();
            Britain.Stop();
            polkaaa.Stop();
            AmericaPl.Stop();
        }
        if (Follow.transform.GetChild(0).CompareTag("British"))
        {
            rus.Stop();
            Britain.Play();
            polkaaa.Stop();
            AmericaPl.Stop();
        }
        if (Follow.transform.GetChild(0).CompareTag("Polka"))
        {
            rus.Stop();
            Britain.Stop();
            polkaaa.Play();
            AmericaPl.Stop();
        }*/
    }
}
