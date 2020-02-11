using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int AmmoCount;
    [SerializeField] private float distance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= .25)
        {
            if (Input.GetKeyDown(KeyCode.E) && AmmoCount -5 >= 0)
            {
                AmmoCount -= 5;
                player.GetComponent<PlayerScript>().increaseCapacity(5);
            }
        }
    }
}
