using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject centreText;
    GameObject instanceText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PrintCenteredText (string message)
    {
        instanceText = Instantiate(centreText);
        instanceText.GetComponentInChildren<textScript>().to_write = message;
    }

    public void RemoveCenteredText ()
    {
        Destroy(instanceText);
    }
}
