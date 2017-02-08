using UnityEngine;
using System.Collections;

public class WonderTile : MonoBehaviour {
    private bool obst = false;
    

    public void Setobs(bool t)
    {
        obst = t;
    }


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (obst)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.tag = "Tile";
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.tag = "Wonder";
        }
    }
}
