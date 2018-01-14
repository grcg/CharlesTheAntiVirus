using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlpha : MonoBehaviour {
    public KeyCode increaseAlpha;
    public KeyCode decreaseAlpha;
    public float alphaLvl = 0f;

    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().color = new Color(alphaLvl, alphaLvl, alphaLvl, alphaLvl);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(increaseAlpha))
        //{/
        alphaLvl += .001f;
        GetComponent<SpriteRenderer>().color = new Color(alphaLvl, alphaLvl, alphaLvl, alphaLvl);
        //}
    }
}
