using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform currentObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(currentObject.position.x, currentObject.position.y, currentObject.position.z - 5);
        transform.position = pos;
    }
}
