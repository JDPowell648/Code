using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour {

    public static GameObject Aggressor;
    public static GameObject Defender;
    public static bool BattleInProgress;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (BattleInProgress)
        {
            Defender.GetComponentInParent<EnemyTestScript>().Control.CurrentHealth = Defender.GetComponentInParent<EnemyTestScript>().Control.CurrentHealth - (Aggressor.GetComponent<TestUnitScript>().Control.Damage);
            BattleInProgress = false;
        }
    }
}
