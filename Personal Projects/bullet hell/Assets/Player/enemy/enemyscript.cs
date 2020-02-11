using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyscript : MonoBehaviour
{
    private static enemyscript something;
    [SerializeField] private int movespeed;
    private float rotationz;
    Rigidbody2D rbody;
    Rigidbody2D rb;
    private Vector3 mouserot;
    private Vector3 prevPos;
    private Vector3 mousepos;
    [SerializeField] Transform turretpos;
    [SerializeField] GameObject self;
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
    [SerializeField] private Transform targetposition;
    [SerializeField] Transform Trajectory;
    [SerializeField] Slider Healthbar;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int Health;
    [SerializeField] private int killvalue;

    public class health
    {
        [SerializeField] public int CurrentHealth;
        [SerializeField] public bool AIColl2D;
    }

    [SerializeField] GameObject deathexprefab;
    [SerializeField] Text Healthtxt;
    Vector3 turretSmooth;
    Vector3 rotSmooth;
    [SerializeField] float turretrotsp;
    [SerializeField] float rotation;
    [SerializeField] Transform AIZone;
    public health enemyHealth = new health();

    void Start()
    {
        enemyHealth.CurrentHealth = MaxHealth;
        Healthbar.value = MaxHealth;
        rbody = GetComponent<Rigidbody2D>();
        prevPos = transform.position;
        ps = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        ps.Play();
        ps.enableEmission = false;
        reloadtimer = reloadspeed;
    }

    // Update is called once per frame
    void Update()
    {
        Healthtxt.text = enemyHealth.CurrentHealth.ToString() + "/" + MaxHealth.ToString();
        Healthbar.maxValue = MaxHealth;
        Healthbar.value = enemyHealth.CurrentHealth;
        if(enemyHealth.CurrentHealth <= 0)
        {
            Transform deathextrans = Instantiate(deathexprefab, transform.position, new Quaternion(), null).transform;
            VictoryMarks.Cash = VictoryMarks.Cash + killvalue;
            Destroy(self);
        }
        turret();
        if (reloaded)
        {
            if (reloaded)
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
        }
        if (reloadtimer <= 0)
        {
            reloaded = true;
        }
        Vector2 movement_vector;
        movement_vector = transform.up;
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * movespeed);
        if (enemyHealth.AIColl2D == false)
        { 
            transform.up = Vector3.SmoothDamp(transform.up, AIZone.transform.position - transform.position, ref rotSmooth, 0, rotation * 100);
        }
        else
        {
            transform.up = transform.up;
        }
    }

    void turret()
    {

        turretpos.transform.up = Vector3.SmoothDamp(turretpos.transform.up, targetposition.position - turretpos.transform.position, ref turretSmooth, 0, turretrotsp * 10);
    }

}
