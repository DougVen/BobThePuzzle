using UnityEngine;
using System.Collections;

public class FallingTile : MonoBehaviour {
    private GameObject cubo;//Bob
    private Vector3 playerpos,inferno;//inferno es el lugar a donde cae
    private bool here = false;//bool para saber si ya estuvo aqui
    
    // Use this for initialization
    void Start () {
        cubo = GameObject.FindGameObjectWithTag("Bob");//encuentro a bob 
        inferno.x = transform.position.x;//seteo pos del infierno
        inferno.y = -10;
    }

    // Update is called once per frame
    void Update()
    {
        //obtengo la posicion del cubo
        playerpos = cubo.transform.position;
        playerpos.y -= 0.5f;

        //si cubo esta aqui 
        if (playerpos == transform.position)
        {
            here = true;
        }

        if(here&& playerpos != transform.position)
        {   
            //cuando el cubo se va lo mando a inferno
            this.transform.position = Vector3.MoveTowards(this.transform.position , inferno, 10 * Time.deltaTime);
        }

    }
}
