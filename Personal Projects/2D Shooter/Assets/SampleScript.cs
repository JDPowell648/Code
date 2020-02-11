using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float range = Vector3.Distance(transform.position, mousePos);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos - transform.position, range);


            Debug.DrawRay(transform.position, (mousePos - transform.position), Color.yellow);


            if (hit.collider != null)
            {
                LineRenderer a = new LineRenderer();
                Debug.Log("Hit!");
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, hit.transform.position);
            }
        }
    }
}
