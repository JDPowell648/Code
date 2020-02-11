using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour {

    public static bool EndTurnBool;
    public static bool EnemyTurn;
    public static bool Victory;
    private float timer;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (EnemyControlScript.TurnOver)
        {
            timer = 0;
            EnemyTurn = false;
            EndTurnBool = false;
        }
	}

    public void EndTurnButton()
    {
        EndTurnBool = true;
        EnemyControlScript.TurnOver = false;
        EnemyControlScript.ChildTurn = 0;
        EnemyTurn = true;
    }
}
