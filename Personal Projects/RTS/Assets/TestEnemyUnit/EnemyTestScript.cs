using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour {

    [SerializeField] private int MaxVision;
    [SerializeField] private int MaxMobility;
    [SerializeField] public Sprite CommanderPortraitSerialized;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int DamageAmt;
    [SerializeField] private int Armor;
    [SerializeField] private float PlayerDistance;
    [SerializeField] private GameObject PlayerControlled;
    [SerializeField] private LineRenderer Line;

    public class RevealClass
    {
        public bool Revealed;
    }
    [System.Serializable]
    public class EnemyControlClass
    {
        public Vector3 pos;
        public int Damage;
        public int Armor;
        public int Vision;
        public Sprite CommanderPortrait;
        public int Mobility;
        public bool isselected;
        public int MaxHealth;
        public int CurrentHealth;
        public GameObject Target;
        public Rigidbody2D rbody;
        public int MoveNum;
        public int MaxAmmo;
        public int Ammo;
        public bool Battled;
    }
    public EnemyControlClass Control = new EnemyControlClass();
    public RevealClass Reveal = new RevealClass();
    // Use this for initialization
    void Start ()
    {
        Control.Ammo = Control.MaxAmmo;
        PlayerControlled = GameObject.Find("PlayerControlled");
        Control.Damage = DamageAmt;
        Control.Armor = Armor;
        Control.Vision = MaxVision;
        Control.MaxHealth = MaxHealth;
        Control.CommanderPortrait = CommanderPortraitSerialized;
        Control.CurrentHealth = MaxHealth;
        Control.Mobility = MaxMobility;
        Control.rbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        PlayerDistanceCheck();
        HealthControl();
        Movement();
        if (EndTurn.EnemyTurn)
        {
            Control.Mobility = MaxMobility;
            Control.MoveNum = 0;
            //Control.MoveDone = false;
            Control.Battled = false;
        }
        if (Reveal.Revealed == true)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Enemy Units";
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        if (EnemySelection.selection == transform)
        {
            Control.isselected = true;
        }
        else
        {
            Control.isselected = false;
        }
    }

    void HealthControl()
    {
        if (Control.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayerDistanceCheck()
    {
        for (int i = 0; i < PlayerControlled.transform.childCount; i++)
        {
            PlayerDistance = Vector2.Distance(PlayerControlled.transform.GetChild(i).position, transform.position);
            if (i == 0)
            {
                Control.Target = PlayerControlled.transform.GetChild(0).gameObject;
            }
            else if (PlayerDistance <= Vector2.Distance(PlayerControlled.transform.GetChild(i - 1).position, transform.position))
            {
                Debug.Log("Updated!");
                Control.Target = PlayerControlled.transform.GetChild(i).gameObject;
                PlayerDistance = Vector2.Distance(Control.Target.transform.position, transform.position);
            }
        }
    }

    void Movement()
    {
        if (EndTurn.EnemyTurn && transform == EnemyControlScript.CurrentChild)
        {
            Control.pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            for (int i = 0; i < Control.Mobility; i++)
            {
                Line.positionCount = i + 1;
                if (i == 0)
                {
                    Line.SetPosition(i, transform.position);
                }
                else if (Control.Target.transform.position.x > Line.GetPosition(i - 1).x)
                {
                    Control.pos.x = Control.pos.x + .64f;
                    Line.SetPosition(i, Control.pos);
                }
                else if (Control.Target.transform.position.x < Line.GetPosition(i - 1).x)
                {
                    Control.pos.x = Control.pos.x - .64f;
                    Line.SetPosition(i, Control.pos);
                }
                else if (Control.Target.transform.position.y > Line.GetPosition(i - 1).y)
                {
                    Control.pos.y = Control.pos.y + .64f;
                    Line.SetPosition(i, Control.pos);
                }
                else if (Control.Target.transform.position.y < Line.GetPosition(i - 1).y)
                {
                    Control.pos.y = Control.pos.y - .64f;
                    Line.SetPosition(i, Control.pos);
                }
                if (Control.Target.transform.position == Line.GetPosition(i))
                {
                    Line.positionCount = (i);
                    break;
                }
            }
            MovementControl();
            Battle();
            EnemyControlScript.ChildTurn = EnemyControlScript.ChildTurn + 1;
        }
    }

    void MovementControl()
    {
        Vector2 v2 = new Vector2(Control.rbody.position.x, Control.rbody.position.y);
        Vector3 v3 = v2;
        if (Control.MoveNum < Line.numPositions)
        {
            if (Control.MoveNum + 1 < Line.numPositions)
            {
                Control.MoveNum = Control.MoveNum + 1;
                transform.position = (Line.GetPosition(Control.MoveNum));
                Control.Mobility = Control.Mobility - 1;
            }
        }
    }

    void Battle()
    {
            if (Control.Battled == false && Control.Ammo > 0)
            {
                if (PlayerDistance <= .65)
                {
                    Control.Ammo = Control.Ammo - 1;
                    Debug.Log(gameObject.ToString() + " Can Battle " + Control.Target.gameObject.ToString() + " !");
                    EnemyBattleScript.BattleInProgress = true;
                    EnemyBattleScript.Aggressor = transform.gameObject;
                    EnemyBattleScript.Defender = Control.Target.gameObject;
                    Control.Battled = true;
                }
            }
    }
}
