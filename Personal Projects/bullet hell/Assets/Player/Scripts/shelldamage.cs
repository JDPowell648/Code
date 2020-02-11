using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelldamage : MonoBehaviour {

    [SerializeField] private int damagedeal;
    [SerializeField] GameObject explosionprefab;
    [SerializeField] AudioClip collide;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            other.GetComponent<enemyscript>().enemyHealth.CurrentHealth = other.GetComponent<enemyscript>().enemyHealth.CurrentHealth - damagedeal;
        }
            Transform explostiontrans = Instantiate(explosionprefab, transform.position, new Quaternion(), null).transform;
            AudioSource.PlayClipAtPoint(collide, transform.position, 2f);
            Destroy(gameObject);
        
    }
}
