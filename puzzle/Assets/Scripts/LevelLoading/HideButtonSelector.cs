using UnityEngine;
using System.Collections;

public class HideButtonSelector : MonoBehaviour {
    private bool flag;
	// Use this for initialization
	void Start () {
        this.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        this.GetComponentsInChildren<BoxCollider2D>()[1].enabled = false;
    }

    public void enableLoader()
    {
        this.GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        this.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
    }

    public void disableLoader()
    {
        this.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        this.GetComponentsInChildren<BoxCollider2D>()[1].enabled = false;
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
