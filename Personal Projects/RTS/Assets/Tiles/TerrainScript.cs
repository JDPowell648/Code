using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour {

    [SerializeField] GameObject Fog;
    [SerializeField] bool LocalReveal;
    [SerializeField] bool LocalOccupied;
    [SerializeField] GameObject Border;

    public class RevealClass
    {
        public bool Revealed;
        public bool Attackable;
        public bool Occupied;
    }
    public RevealClass Reveal = new RevealClass();

    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update() {
        LocalReveal = Reveal.Revealed;
        LocalOccupied = Reveal.Occupied;
        if (Reveal.Revealed == true)
        {
            Fog.SetActive(false);
        }
        else
        {
            Fog.SetActive(true);
        }
        if (transform.GetChild(3).GetComponent<Occupied>().Occupy.Occupied)
        {
            Reveal.Occupied = true;
        }
        else
        {
            Reveal.Occupied = false;
        }
        if (transform.GetChild(4).GetComponent<Attackable>().Occupy.Occupied)
        {
            transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        }
        if(TerrainSelection.selection == transform)
        {
            Border.SetActive(true);
            transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            Border.SetActive(false);
            transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Reveal.Revealed = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Reveal.Revealed = true;
    }
}
