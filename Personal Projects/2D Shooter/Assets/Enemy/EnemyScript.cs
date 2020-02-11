using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public LivingObject livingObject = new LivingObject(100);
    [SerializeField] private int currentHealth;
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private GameObject parent;
    [SerializeField] private Transform obj;
    [SerializeField] private LayerMask attackMask;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = livingObject.getHealth();
        checkHealth();
        HealthSlider.maxValue = livingObject.getMaxHealth();
        HealthSlider.value = livingObject.getHealth();
    }

    void checkHealth()
    {
        if(livingObject.getHealth() <= 0)
        {
            GameObject.Destroy(parent);
        }
    }

    public bool rayToPlayer()
    {
        float range = Vector3.Distance(transform.position, obj.transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, obj.position - transform.position, range, attackMask);
        Debug.DrawRay(transform.position, (obj.position - transform.position), Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Map"))
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public bool gunRayToPlayer()
    {
        float range = Vector3.Distance(transform.GetChild(1).position, obj.transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.GetChild(1).position, obj.position - transform.GetChild(1).position, range, attackMask);


        Debug.DrawRay(transform.GetChild(1).position, (obj.position - transform.GetChild(1).position), Color.yellow);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Map"))
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    private void fireWeapon()
    {
        
    }

}
