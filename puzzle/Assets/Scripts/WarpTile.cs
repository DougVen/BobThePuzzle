using UnityEngine;
using System.Collections;

public class WarpTile : MonoBehaviour {
    private GameObject cubo;
    public GameObject destiny;//a donde mando el cubo
    private Vector3 playerpos;
    private bool here = false;

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
            here = true;
        }

        if (here && playerpos != transform.position)
        {
         //   this.transform.position = Vector3.MoveTowards(this.transform.position, inferno, 10 * Time.deltaTime);
        }

    }
}
