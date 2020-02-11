using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour {

    public GameObject explosion;
    Animator anim;
    public static bool landed;

    // Use this for initialization
    void Start () {
        landed = false;
        anim = explosion.transform.GetComponent<Animator>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        landed = true;
        explosion.SetActive(true);
        anim.SetBool("Landed", true);
        gameObject.SetActive(false);
    }
}
