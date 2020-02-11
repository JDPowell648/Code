using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlScript : MonoBehaviour {
    
    [SerializeField] public static int ChildTurn;
    [SerializeField] public static Transform CurrentChild;
    public static bool TurnOver;

	void Start ()
    {
        ChildTurn = 0;
        TurnOver = true;
	}
	
	
	void Update ()
    {
        if (!TurnOver)
        {
            if (transform.childCount == 0)
            {
                EndTurn.Victory = true;
                Application.Quit();
            }
            else if (ChildTurn <= transform.childCount && ChildTurn == 0)
            {
                CurrentChild = transform.GetChild(0);
            }
            else if (ChildTurn <= transform.childCount && ChildTurn != 0)
            {
                CurrentChild = transform.GetChild(ChildTurn - 1);
            }
            else if (ChildTurn > transform.childCount + 1)
            {
                TurnOver = true;
            }
        }
	}
}
