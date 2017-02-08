using UnityEngine;
using System.Collections;

public class ObstacleTile : MonoBehaviour {

    // Use this for initialization

    private bool obst = false;
    public bool inverse = false;

    public void Setobs(bool t)
    {
        obst = t;
    }
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {

        if (obst)
        {
            if (!inverse)
            {
                this.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
                this.tag = "Tile";
            }else
            {
                this.GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
                this.tag = "Obstacle";
            }
           
        }else
        {
            if (!inverse)
            {
                this.tag = "Obstacle";
            }
            else
            {
                this.tag = "Tile";
            }
            
        }

    }
}
