using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {
	
	public Sprite backgroundSprite;
	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void DrawBackground(int minX, int minY, int maxX, int maxY) {
		//take width and height of backgroundSprite and figure out how many times it needs to be tiled
		//then create that many?
		
		int horizNeeded;
		int vertiNeeded;

	}
}
