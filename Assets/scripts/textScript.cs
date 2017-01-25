using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour {
    Text contents;
    public string to_write;

	// Use this for initialization
	void Start () {
        contents = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        contents.text = to_write;
	}
}
