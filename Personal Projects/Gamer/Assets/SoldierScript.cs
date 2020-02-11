using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{

    //followcrosshair
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private Transform CrosshairLocation;
    [SerializeField] private float gunangle;
    //boom
    Animator anim;
    //fire
    [SerializeField] private GameObject Barrel;
    [SerializeField] private Transform Barrelpos;
    Rigidbody2D rb;
    //followmouse
    Vector3 pos;
    //original
    [SerializeField] private bool isselected;
    private SpriteRenderer Sprite;
    Rigidbody2D rbody;
    private ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        Sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        isselected = false;
        Crosshair.SetActive(true);
        ps = transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        ps.Play();
        ps.enableEmission = false ;
        //followcrosshair
        //boom
        //fire
        //followmouse
    }

    // Update is called once per frame
    void Update()
    {
        if (Selection.selection == transform.GetChild(0).transform)
        {
            isselected = true;
            Sprite.color = Color.red;
        }
        else
        {
            isselected = false;
            Sprite.color = Color.white;
        }
        //followcrosshair
        gunangle = Gun.transform.localRotation.eulerAngles.z;
        Gun.transform.right = (CrosshairLocation.position - Gun.transform.position).normalized;
        //boom
        //fire
        //followmouse
        if (isselected == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Crosshair.SetActive(true);
                Crosshair.transform.position = pos;
                Vector3 mousepos;
                mousepos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
                pos.x = mousepos.x;
                pos.y = mousepos.y;

            }
            else
            {
                Crosshair.SetActive(false);
            }
        }
        else
        {
            Crosshair.SetActive(false);
        }
        if (isselected == true)
        {
            Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime*5);
            if (Input.GetMouseButton(1))
            {
                ps.enableEmission = true;
            }
            else
            {
                ps.enableEmission = false;
            }
        }
    }
}
