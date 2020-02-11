using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {

	public void OnClickPick(int whichChar)
    {
        if(PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedCharacter = whichChar;
            PlayerPrefs.SetInt("MyCharacter", whichChar);
        }
    }
}
