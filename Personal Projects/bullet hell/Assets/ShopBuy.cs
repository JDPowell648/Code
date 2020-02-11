using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuy : MonoBehaviour {

    [SerializeField] GameObject Item;
    [SerializeField] int Price;
    [SerializeField] Button BuyButton;
    [SerializeField] Text PriceText;
    [SerializeField] GameObject Follow;

    public class bought
    {
        [SerializeField] public bool Bought;
    }
    public bought itemBought = new bought();

    private void Awake()
    {
        PriceText.text = "This Costs: " + Price.ToString();
        Follow = GameObject.Find("Player");
    }
    void Start () {
        
    }

    private void Update()
    {
        Follow = GameObject.Find("Player");
    }

    public void SpawnItem() {
		if(itemBought.Bought == true)
        {
            Transform itemtrans = Instantiate(Item, Follow.transform.GetChild(0).position, new Quaternion(), null).transform;
            itemtrans.transform.parent = Follow.transform;
            itemtrans.transform.up = Follow.transform.GetChild(0).up;
            Destroy(Follow.transform.GetChild(0).gameObject);
            itemBought.Bought = false;
        }
	}

    public void BuyItem()
    {
        if(VictoryMarks.Cash >= Price && itemBought.Bought == false)
        {
            VictoryMarks.Cash = VictoryMarks.Cash - Price;
            itemBought.Bought = true;
        }
    }
}
