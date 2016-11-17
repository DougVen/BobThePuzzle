using UnityEngine;
using System.Collections;

public class WinningTile : MonoBehaviour {

    public bool win =  true;
    public Canvas NextLevel,NextLevel2;
    private GameObject cubo;
    private Vector3 playerpos;
    
    //dirigo a cubo a una variable
    void Start()
    {
        cubo = GameObject.FindGameObjectWithTag("Bob");
        NextLevel2.transform.position=new Vector3(0, -18, 0);
        NextLevel.GetComponent<Canvas>().enabled = false;
        NextLevel2.GetComponent<Canvas>().enabled = false;

       
    }

    void Update()
    {
        //obtengo la posicion del cubo
        playerpos = cubo.transform.position;
        playerpos.y -= 0.5f;
       
        //si cubo esta en winning tile que active el canvas
        if (playerpos == transform.position)
        {
            NextLevel.GetComponent<Canvas>().enabled = true;
            NextLevel2.GetComponent<Canvas>().enabled = true;
        }

    }

}
