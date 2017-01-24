using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public Object centreText;
    Object instanceText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PrintCenteredText ()
    {
        instanceText = Instantiate(centreText);
    }

    public void RemoveCenteredText ()
    {
        Destroy(instanceText);
    }
}
