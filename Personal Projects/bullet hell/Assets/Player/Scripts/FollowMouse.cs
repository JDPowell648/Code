using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] Transform position2;
    Vector3 pos;
    public static Transform position1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position2.transform.position = transform.position;
        position1 = position2;
        transform.position = pos;
        Vector3 mousepos;
        mousepos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            pos.x = mousepos.x;
            pos.y = mousepos.y;
    }
}
