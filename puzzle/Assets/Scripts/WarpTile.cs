using UnityEngine;
using System.Collections;

public class WarpTile : MonoBehaviour {
    private GameObject cubo;
    public GameObject destinycube;//a donde mando el cubo
    private Vector3 playerpos,destiny;


    // Use this for initialization
    void Start()
    {
        cubo = GameObject.FindGameObjectWithTag("Bob");

    }

    // Update is called once per frame
    void Update()
    {
        //obtengo la posicion del cubo
        playerpos = cubo.transform.position;
        playerpos.y -= 0.5f;

        //si cubo esta en winning tile que active el canvas
        if (playerpos == transform.position)
        {
			Invoke("Teleport",0.3f);
        }

    }

	void Teleport(){
		destiny = destinycube.transform.position;
		destiny.y += 0.5f;
		cubo.transform.position = destiny;
	}
}
