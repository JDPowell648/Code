using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleScript : MonoBehaviour
{

    public static GameObject Aggressor;
    public static GameObject Defender;
    public static bool BattleInProgress;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BattleInProgress)
        {
            Defender.GetComponentInParent<TestUnitScript>().Control.CurrentHealth = Defender.GetComponentInParent<TestUnitScript>().Control.CurrentHealth - (Aggressor.GetComponent<EnemyTestScript>().Control.Damage);
            BattleInProgress = false;
        }
    }
}
