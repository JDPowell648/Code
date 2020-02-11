using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField] private LayerMask PlayerUnits;
    [SerializeField] public static Transform selectionhover;
    [SerializeField] public static Transform selection;
    private GameObject selectioncontrol;
    // Use this for initialization
    void Start()
    {
        selectioncontrol = GameObject.Find("SelectionControl");
    }

    // Update is called once per frame
    void Update()
    {

        SelectEnemy();
        if (Input.GetMouseButtonDown(0) && selectionhover != null)
        {
            selection = selectionhover;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            selection = null;
        }

    }
    private void SelectEnemy()
    {
        RaycastHit2D raycast = Physics2D.Raycast(selectioncontrol.transform.position, Vector2.zero, 100000, PlayerUnits);
        if (raycast)
        {
            selectionhover = raycast.collider.transform;
            return;
        }
        selectionhover = null;
    }
}
