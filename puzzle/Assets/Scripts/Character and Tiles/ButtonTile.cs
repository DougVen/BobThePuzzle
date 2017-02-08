using UnityEngine;
using System.Collections;

public class ButtonTile : MonoBehaviour {
    public GameObject obstacle;
    private GameObject cubo;
	// Use this for initialization
	void Start () {
        cubo = GameObject.FindGameObjectWithTag("Bob");
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 hey = cubo.transform.position;
        hey.y -= 0.5f;
        if (hey == this.transform.position)
        {
            obstacle.GetComponent<ObstacleTile>().Setobs(true);
            if (transform.childCount>1)
            {
                this.GetComponentsInChildren<SpriteRenderer>()[2].enabled = true;
                this.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
            }
            
        }
	}
}
