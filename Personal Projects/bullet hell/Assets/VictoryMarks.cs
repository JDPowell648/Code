using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryMarks : MonoBehaviour {

    private static VictoryMarks something;
    public static int Cash;
    [SerializeField] int startercash;
	[SerializeField] Text UICash;

    private void Awake()
    {
        if (something == null)
        {
            something = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start () {
        startercash = 300;
        Cash = startercash + Cash;
	}
	
	// Update is called once per frame
	void Update () {
        UICash.text = "Cash Money: " + Cash.ToString();
	}
}
