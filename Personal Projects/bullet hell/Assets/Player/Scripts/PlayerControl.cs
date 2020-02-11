using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl: MonoBehaviour
{
    private static PlayerControl something;
    public static Transform vehiclepos;
    private int movespeed;
    [SerializeField] private int maxspeed;
    private float rotationz;
    Rigidbody2D rbody;
    Rigidbody2D rb;
    [SerializeField] Transform shellspawn;
    [SerializeField] float mousex;
    [SerializeField] float mousey;
    [SerializeField] float turretrotx;
    [SerializeField] float turretroty;
    private ParticleSystem ps;
    [SerializeField] private float reloadtimer;
    [SerializeField] private float reloadspeed;
    [SerializeField] private bool reloaded;
    [SerializeField] int velocity;
    [SerializeField] GameObject shellprefab;
    [SerializeField] AudioClip fire;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int Health;
    [SerializeField] public static int CurrentHealth;
    private Transform mousepos;
    [SerializeField] Transform Trajectory;
    [SerializeField] Transform turretpos;
    [SerializeField] Slider Healthbar;
    [SerializeField] Text Reloadtxt;
    [SerializeField] Text Healthtxt;
    [SerializeField] float rotation;
    [SerializeField] float turretrotsp;
    [SerializeField] private GameObject realmousepos;
    private GameObject Mouse;
    Vector3 turretSmooth;
    Vector3 pos;
    [SerializeField] GameObject deathexprefab;
    [SerializeField] GameObject NoVehiclePre;
    GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
        realmousepos = GameObject.Find("MousePos");
        CurrentHealth = MaxHealth;
        Healthbar.value = MaxHealth;
        rbody = GetComponent<Rigidbody2D>();
        ps = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        ps.Play();
        ps.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EscapeMenu.paused == false)
        {
            Healthtxt.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
            Healthbar.maxValue = MaxHealth;
            Healthbar.value = CurrentHealth;
            Health = CurrentHealth;
            if (reloaded)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    AudioSource.PlayClipAtPoint(fire, shellspawn.position);
                    Transform shelltransform = Instantiate(shellprefab, shellspawn.position, new Quaternion(), null).transform;
                    rb = shelltransform.GetComponent<Rigidbody2D>();
                    rb.velocity = (Trajectory.transform.position - shelltransform.transform.position).normalized * velocity;
                    shelltransform.up = rb.velocity.normalized;
                    ps.Play();
                    ps.enableEmission = true;
                    reloadtimer = reloadspeed;
                    reloaded = false;
                }
                else
                {
                    ps.Stop();
                }
            }
            if (reloadtimer > 0)
            {
                reloadtimer -= Time.deltaTime;
                Reloadtxt.text = reloadtimer.ToString("#.00");
                Reloadtxt.color = Color.red;
            }
            if (reloadtimer <= 0)
            {
                reloaded = true;
                Reloadtxt.text = "Loaded";
                Reloadtxt.color = Color.green;
            }
            Vector2 movement_vector;
            movement_vector = transform.up * Input.GetAxisRaw("Vertical");
            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * movespeed);

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.eulerAngles += new Vector3(0, 0, -rotation);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.eulerAngles += new Vector3(0, 0, rotation);
            }
            if (Health <= 0)
            {
                Transform deathextrans = Instantiate(deathexprefab, transform.position, new Quaternion(), null).transform;
                Transform NoVehicle = Instantiate(NoVehiclePre, transform.position, new Quaternion(), null).transform;
                NoVehicle.transform.parent = Player.transform; 
                Destroy(gameObject);
            }
            turretpos.transform.up = Vector3.SmoothDamp(turretpos.transform.up, realmousepos.transform.position - turretpos.transform.position, ref turretSmooth, 0, turretrotsp * 10);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movespeed = maxspeed / 3;
            }
            else
            {
                movespeed = maxspeed;
            }
        }
    }
}
