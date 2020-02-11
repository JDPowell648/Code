using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshell : MonoBehaviour
{

    [SerializeField] private int damagedeal;
    [SerializeField] GameObject explosionprefab;
    [SerializeField] AudioClip collide;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Transform explostiontrans = Instantiate(explosionprefab, transform.position, new Quaternion(), null).transform;
        AudioSource.PlayClipAtPoint(collide, transform.position, .5f);
        PlayerControl.CurrentHealth = PlayerControl.CurrentHealth - damagedeal;
        Destroy(gameObject);
    }
}
