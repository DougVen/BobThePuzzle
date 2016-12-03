using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flecha : MonoBehaviour {

    // Use this for initialization
    public string direccion="hola";
    private int Turns;
    public Text text;
    private GameObject cubo;
    private GameObject[] Tiles;
    private Sprite front, back;
    Vector3 cubopos,tilepos, winningpos;
    public Animator anim;
    bool flag = false,mover=false,tmrflag=true , ok = false;
    float timeLeft = 0f;


    void Start () {
        Turns = int.Parse(text.text);

        cubo = GameObject.FindGameObjectWithTag("Bob");
        cubopos = cubo.transform.position;
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        text.text = Turns + "";    
    }
    private void cooldown()
    {
        tmrflag = true;
    }
    public void OnMouseDown()
    {
        if (tmrflag && Time.timeScale != 0)
        {
            flag = true;
            Invoke("cooldown", 0.25f);
            tmrflag = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Turns = int.Parse(text.text);

        // Ok es un bool que ayuda para mover la cara de bob hacia el mismo lugar despues de un 0.25 seg de espera.
        if (ok)
        {
            timeLeft += Time.deltaTime;
            if (timeLeft > 0.25)
            {
                cubo.GetComponent<SpriteRenderer>().flipX = false;
                cubo.GetComponent<SpriteRenderer>().sprite = front;
                timeLeft = 0;
                ok = false;
            }
        }



        if (flag&&Turns>0)
        {
            bool exist = false;
            cubopos =cubo.transform.position;
            tilepos = cubopos;
            tilepos.y -= 0.5f;
            arrangeTilePos();
            foreach(GameObject t in Tiles)
            {
                if (t.transform.position == tilepos)
                {
                    exist = true;
   
                }             
               
            }
            if (exist)
            {
                anim.Play("JumpingBob");
                arrangePos();
                mover = true;
                Turns--;
                text.text = Turns + "";
                

            }
            else
            {
                print("no hay nada");
            }
            flag = false;

            if (Turns == 0)
                this.gameObject.GetComponent<Button>().interactable = false;
               
        }

        if ((cubo.transform.position != cubopos) && mover)
        {
            cubo.transform.position = Vector3.MoveTowards(cubo.transform.position, cubopos, 5 * Time.deltaTime);
            
        }
        else
        {
            mover = false;
        }
    }

    private void arrangeTilePos()
    {
        switch (direccion)
        {
            case "Arriba":
                tilepos.x += 0.72f;
                tilepos.y += 0.42f;
                break;
            case "Abajo":
                tilepos.x -= 0.72f;
                tilepos.y -= 0.42f;
                break;
            case "Derecha":
                tilepos.x += 0.72f;
                tilepos.y -= 0.42f;
                break;
            case "Izquierda":
                tilepos.x -= 0.72f;
                tilepos.y += 0.42f;
                break;
            default:
                print("hola");
                break;
        }



    }
    private void arrangePos()
    {

        front = cubo.GetComponent<BobSkins>().front;
        back = cubo.GetComponent<BobSkins>().back;
        switch (direccion)
        {
            case "Arriba":
                cubo.GetComponent<SpriteRenderer>().flipX = false;
                cubo.GetComponent<SpriteRenderer>().sprite = back;
                cubopos.x += 0.72f;
                cubopos.y += 0.42f;
                break;
            case "Abajo":
                cubo.GetComponent<SpriteRenderer>().flipX = false;
                cubo.GetComponent<SpriteRenderer>().sprite = front;
                cubopos.x -= 0.72f;
                cubopos.y -= 0.42f;
                break;  
            case "Derecha":
                cubo.GetComponent<SpriteRenderer>().flipX = true;
                cubo.GetComponent<SpriteRenderer>().sprite = front;
                cubopos.x += 0.72f;
                cubopos.y -= 0.42f;
                break;
            case "Izquierda":
                cubo.GetComponent<SpriteRenderer>().flipX = true;
                cubo.GetComponent<SpriteRenderer>().sprite = back;
                cubopos.x -= 0.72f;
                cubopos.y += 0.42f;
                break;
            default:
                print("hola");
                break;
        }
        ok = true;
    }
}
