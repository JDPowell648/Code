using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitInfoScript : MonoBehaviour {

    [SerializeField] Image Commander;
    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI Vision;
    [SerializeField] TextMeshProUGUI Fuel;
    [SerializeField] TextMeshProUGUI Ammo;
    [SerializeField] GameObject Panel;
    [SerializeField] Slider Health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Selection.selectionhover != null)
        {
            Panel.SetActive(true);
            Panel.transform.GetComponent<Image>().color = Color.blue;
            Commander.sprite = Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.CommanderPortrait;
            HP.text = "Health: " + Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.CurrentHealth.ToString() + "/" + Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.MaxHealth.ToString();
            Health.maxValue = Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.MaxHealth;
            Health.value = Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.CurrentHealth;
            Vision.text = "Vision: " + Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.Vision.ToString();
            Fuel.text = "Fuel: " + Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.Fuel.ToString() + "/" + Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.MaxFuel.ToString();
            Ammo.text = "Ammo: " + Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.Ammo.ToString() + "/" + Selection.selectionhover.GetComponentInParent<TestUnitScript>().Control.MaxAmmo.ToString();
        }
        else if (EnemySelection.selection != null && EnemySelection.selection.GetComponent<EnemyTestScript>().Reveal.Revealed)
        {
            Panel.SetActive(true);
            Panel.transform.GetComponent<Image>().color = Color.red;
            Commander.sprite = EnemySelection.selection.GetComponent<EnemyTestScript>().Control.CommanderPortrait;
            HP.text = "Health: " + EnemySelection.selection.GetComponent<EnemyTestScript>().Control.CurrentHealth.ToString() + "/" + EnemySelection.selection.GetComponent<EnemyTestScript>().Control.MaxHealth.ToString();
            Health.maxValue = EnemySelection.selection.GetComponent<EnemyTestScript>().Control.MaxHealth;
            Health.value = EnemySelection.selection.GetComponent<EnemyTestScript>().Control.CurrentHealth;
            Vision.text = "Vision: " + EnemySelection.selection.GetComponentInParent<EnemyTestScript>().Control.Vision.ToString();
        }
        else if (Selection.selection != null && Selection.selectionhover == null)
        {
            Panel.SetActive(true);
            Panel.transform.GetComponent<Image>().color = Color.blue;
            Commander.sprite = Selection.selection.GetComponentInParent<TestUnitScript>().Control.CommanderPortrait;
            HP.text = "Health: " + Selection.selection.GetComponentInParent<TestUnitScript>().Control.CurrentHealth.ToString() + "/" + Selection.selection.GetComponentInParent<TestUnitScript>().Control.MaxHealth.ToString();
            Vision.text = "Vision: " + Selection.selection.GetComponentInParent<TestUnitScript>().Control.Vision.ToString();
            Health.maxValue = Selection.selection.GetComponentInParent<TestUnitScript>().Control.MaxHealth;
            Health.value = Selection.selection.GetComponentInParent<TestUnitScript>().Control.CurrentHealth;
            Fuel.text = "Fuel: " + Selection.selection.GetComponentInParent<TestUnitScript>().Control.Fuel.ToString() + "/" + Selection.selection.GetComponentInParent<TestUnitScript>().Control.MaxFuel.ToString();
            Ammo.text = "Ammo: " + Selection.selection.GetComponentInParent<TestUnitScript>().Control.Ammo.ToString() + "/" + Selection.selection.GetComponentInParent<TestUnitScript>().Control.MaxAmmo.ToString();
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
