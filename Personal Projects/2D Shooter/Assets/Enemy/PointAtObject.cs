using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform obj;
    [SerializeField] private float distance;
    void Start()
    {
        obj = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (obj != null)
        {
            Vector3 pos = new Vector3();

            pos.x = obj.position.x - transform.position.x;
            pos.y = obj.position.y - transform.position.y;

            distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance <= 5 && transform.GetComponent<EnemyScript>().rayToPlayer())
            {
                float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            }
        }
    }
}
