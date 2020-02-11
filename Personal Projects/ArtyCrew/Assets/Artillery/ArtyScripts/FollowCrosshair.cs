using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCrosshair : MonoBehaviour {
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private Transform CrosshairLocation;
    [SerializeField] public static float gunangle;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        gunangle = transform.localRotation.eulerAngles.z;
        transform.right = (CrosshairLocation.position - transform.position).normalized;

    }

}
