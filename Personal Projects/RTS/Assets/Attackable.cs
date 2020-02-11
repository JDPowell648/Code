using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    GameObject Player;
    public class OccupiedClass
    {
        public bool Occupied;
    }
    public OccupiedClass Occupy = new OccupiedClass();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        Occupy.Occupied = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Occupy.Occupied = true;
    }
}
