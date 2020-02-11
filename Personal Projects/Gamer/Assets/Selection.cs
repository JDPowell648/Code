using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField] private LayerMask Artillery;
    [SerializeField] private Transform selectionhover;
    [SerializeField] public static Transform selection;
    // Use this for initialization
    void Start()
    {
        selectionhover = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectEnemy();
            selection = selectionhover;
        }
    }
    private void SelectEnemy()
    {
        RaycastHit2D raycast = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Artillery);
        if (raycast)
        {
            selectionhover = raycast.collider.transform;
            return;
        }
        selectionhover = null;
    }
}
