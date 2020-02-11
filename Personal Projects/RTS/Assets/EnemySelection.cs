using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelection : MonoBehaviour
{
    [SerializeField] private LayerMask EnemyUnits;
    [SerializeField] private Transform selectionhover;
    [SerializeField] public static Transform selection;
    private GameObject selectioncontrol;
    // Use this for initialization
    void Start()
    {
        selectionhover = null;
        selectioncontrol = GameObject.Find("SelectionControl");
    }

    // Update is called once per frame
    void Update()
    {
            SelectEnemy();
            selection = selectionhover;
    }
    private void SelectEnemy()
    {
        RaycastHit2D raycast = Physics2D.Raycast(selectioncontrol.transform.position, Vector2.zero, 100000, EnemyUnits);
        if (raycast)
        {
            selectionhover = raycast.collider.transform;
            return;
        }
        selectionhover = null;
    }
}
