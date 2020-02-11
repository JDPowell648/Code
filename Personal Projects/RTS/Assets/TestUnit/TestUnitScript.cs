using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUnitScript : MonoBehaviour {

    [SerializeField] private int MaxVision;
    [SerializeField] private int MaxAmmo;
    [SerializeField] private int MaxMobility;
    [SerializeField] private int MaxFuel;
    [SerializeField] private LayerMask Terrain;
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private GameObject Line;
    [SerializeField] private GameObject EnemyOutline;
    [SerializeField] GameObject Border;
    private SpriteRenderer BorderSprite;
    [SerializeField] public Transform selectionhover2;
    [SerializeField] public Sprite CommanderPortraitSerialized;
    [SerializeField] private int MaxHealth;
    [SerializeField] private Vector3 DiePos;
    [SerializeField] private int DamageAmt;
    [SerializeField] private int Armor;
    private GameObject selectioncontrol;
    [System.Serializable]
    public class ControlClass
    {
        public int Damage;
        public int Armor;
        public bool lockcont;
        public int Fuel;
        public int MaxFuel;
        public int MaxAmmo;
        public int Ammo;
        public int Vision;
        public Sprite CommanderPortrait;
        public int Mobility;
        public int MaxMobility;
        public bool isselected;
        public Transform selectionhover;
        public Transform EnemyHover;
        public int SelectionNum;
        public bool MoveDone;
        public int MoveNum;
        public Rigidbody2D rbody;
        public LineRenderer Arrow;
        public int CurrentHealth;
        public int MaxHealth;
        public bool Battled;
    }

    public ControlClass Control = new ControlClass();

    void Start ()
    {
        Control.Damage = DamageAmt;
        Control.Armor = Armor;
        Control.MoveNum = 0;
        selectioncontrol = GameObject.Find("SelectionControl");
        DiePos.x = transform.position.x + 10000;
        DiePos.y = transform.position.y + 10000;
        Control.Fuel = MaxFuel;
        Control.MaxFuel = MaxFuel;
        Control.Vision = MaxVision;
        Control.MaxHealth = MaxHealth;
        Control.Ammo = MaxAmmo;
        Control.MaxAmmo = MaxAmmo;
        Control.CommanderPortrait = CommanderPortraitSerialized;
        Control.CurrentHealth = MaxHealth;
        Control.Mobility = MaxMobility;
        Control.MaxMobility = MaxMobility;
        Control.Arrow = Line.GetComponent<LineRenderer>();
        Control.SelectionNum = 1;
        Control.rbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        EndTurnVoid();
        vision();
        FuelControl();
        MovementSelect();
        MovementControl();
        Battle();
        EnemySelect();
        selectionhover2 = Control.selectionhover;
        if (Selection.selection == Border.transform && Control.lockcont == false)
        {
            Control.isselected = true;
            Control.Arrow.SetPosition(0, transform.position);
            transform.GetChild(3).position = transform.position;
        }
        else
        {
            Control.isselected = false;
            Control.SelectionNum = 1;
            transform.GetChild(3).position = DiePos;
        }
        
    }

    void MovementSelect()
    {
        RaycastHit2D raycast = Physics2D.Raycast(selectioncontrol.transform.position, Vector2.zero, 0.64f, Terrain);
        if (raycast)
        {
            Control.selectionhover = raycast.collider.transform;
            return;
        }
        Control.selectionhover = null;
    }

    void EnemySelect()
    {
        RaycastHit2D raycast = Physics2D.Raycast(selectioncontrol.transform.position, Vector2.zero, 0.64f, EnemyLayer);
        if (raycast && transform.GetChild(3).GetComponent<EnemyCollDetection>().Detect.Detected)
        {
            Control.EnemyHover = raycast.collider.transform;
            return;
        }
        else
        {
            Control.EnemyHover = null;
        }
        Control.selectionhover = null;
    }

    void Movement()
    {
        Vector2 v2 = new Vector2(Control.rbody.position.x, Control.rbody.position.y);
        Vector3 v3 = v2;
        if (Control.MoveNum < Control.Arrow.numPositions)
        {
            if(Control.MoveNum + 1 < Control.Arrow.numPositions)
            {
                Control.MoveNum = Control.MoveNum + 1;
                transform.position = (Control.Arrow.GetPosition(Control.MoveNum));
                Control.Mobility = Control.Mobility - 1;
                Control.Fuel = Control.Fuel - 1;
            }
        }
    }

    void MovementControl()
    {
        if (Control.isselected && !Control.MoveDone)
        {

            if (Input.GetMouseButton(0) && Control.selectionhover != null && Control.Arrow.GetPosition(Control.SelectionNum - 1) != Control.selectionhover.position)
            {
                Line.SetActive(true);
                Control.Arrow.positionCount = Control.SelectionNum;
                if (Control.SelectionNum <= Control.Mobility && Control.SelectionNum <= Control.Fuel)
                {
                    if (Vector3.Distance(Control.Arrow.GetPosition(Control.SelectionNum - 1), Control.selectionhover.position) <= 0.75f)
                    {
                        if ((Control.SelectionNum >= 3) && (Control.Arrow.GetPosition(Control.SelectionNum - 2) == Control.selectionhover.position))
                        {
                            Control.SelectionNum = Control.SelectionNum - 1;
                            Control.Arrow.positionCount = Control.SelectionNum;
                        }
                        else if ((Control.SelectionNum <= 3) && (Control.Arrow.GetPosition(0) == Control.selectionhover.position))
                        {
                            Control.SelectionNum = Control.SelectionNum - 1;
                            Control.Arrow.positionCount = Control.SelectionNum;
                        }
                        else if (Control.selectionhover.GetComponent<TerrainScript>().Reveal.Revealed && Control.SelectionNum <= Control.Mobility - 1 && !Control.selectionhover.GetComponent<TerrainScript>().Reveal.Occupied)
                        {
                            Control.SelectionNum = Control.SelectionNum + 1;
                            Control.Arrow.positionCount = Control.SelectionNum;
                            Control.Arrow.SetPosition(Control.SelectionNum - 1, Control.selectionhover.position);
                        }
                    }
                }
            }
        }
        else
        {
            Line.SetActive(false);
        }
        if (Control.isselected && Input.GetKey(KeyCode.Space) && transform.position != Control.Arrow.GetPosition(Control.SelectionNum - 1))
        {
            Control.MoveDone = true;
            Movement();
        }
    }

    void vision()
    {
        transform.GetComponent<CircleCollider2D>().radius = Control.Vision * .64f;
    }

    void FuelControl()
    {

    }

    void EndTurnVoid()
    {
        if (EndTurn.EndTurnBool == true)
        {
            Control.lockcont = true;
            Control.Mobility = Control.MaxMobility;
            Control.MoveNum = 0;
            Control.MoveDone = false;
            Control.Battled = false;
        }
        else if (EndTurn.EnemyTurn == false)
        {
            Control.lockcont = false;
        }
    }

    void Battle()
    {
        if (transform.GetChild(3).GetComponent<EnemyCollDetection>().Detect.Detected)
        {
            if (Input.GetMouseButton(0) && Control.Battled == false && Control.Ammo > 0)
            {
                if (Control.EnemyHover != null)
                {
                    Control.Ammo = Control.Ammo - 1;
                    Debug.Log(gameObject.ToString() + " Can Battle " + Control.EnemyHover.gameObject.ToString() + " !");
                    BattleScript.BattleInProgress = true;
                    BattleScript.Aggressor = transform.gameObject;
                    BattleScript.Defender = Control.EnemyHover.gameObject;
                    Control.Battled = true;
                }
            }
        }
    }
}

