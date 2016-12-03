using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Swipe : MonoBehaviour {
    private int Turns;
    public Text text;
    public float dx, dy,high;
    private GameObject cubo;
    private GameObject[] Tiles;
    private Sprite front, back;
    Vector3 cubopos, tilepos, winningpos;
    public Animator anim;
    bool flag = false, mover = false, tmrflag = true, ok = false;
    bool exist = false;

    // Use this for initialization
    void Start()
    {
        

        cubo = GameObject.FindGameObjectWithTag("Bob");
        cubopos = cubo.transform.position;
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        if (text != null)
        {
            Turns = int.Parse(text.text);
            text.text = Turns + "";
        }
    }
    private void arrangeTilePos(string direccion)
    {
        switch (direccion)
        {
            case "Arriba":
                tilepos.x += dx;
                tilepos.y += dy;
                break;
            case "Abajo":
                tilepos.x -= dx;
                tilepos.y -= dy;
                break;
            case "Derecha":
                tilepos.x += dx;
                tilepos.y -= dy;
                break;
            case "Izquierda":
                tilepos.x -= dx;
                tilepos.y += dy;
                break;
            default:
                print("hola");
                break;
        }



    }
    private void arrangePos(string direccion)
    {

        front = cubo.GetComponent<BobSkins>().front;
        back = cubo.GetComponent<BobSkins>().back;
        switch (direccion)
        {
            case "Arriba":
                cubo.GetComponent<SpriteRenderer>().flipX = false;
                cubo.GetComponent<SpriteRenderer>().sprite = back;
                cubopos.x += dx;
                cubopos.y += dy;
                break;
            case "Abajo":
                cubo.GetComponent<SpriteRenderer>().flipX = false;
                cubo.GetComponent<SpriteRenderer>().sprite = front;
                cubopos.x -= dx;
                cubopos.y -= dy;
                break;
            case "Derecha":
                cubo.GetComponent<SpriteRenderer>().flipX = true;
                cubo.GetComponent<SpriteRenderer>().sprite = front;
                cubopos.x += dx;
                cubopos.y -= dy;
                break;
            case "Izquierda":
                cubo.GetComponent<SpriteRenderer>().flipX = true;
                cubo.GetComponent<SpriteRenderer>().sprite = back;
                cubopos.x -= dx;
                cubopos.y += dy;
                break;
            default:
                print("hola");
                break;
        }
        ok = true;
    }
    private void move(string direccion)//revisa que existe si existe se mueve
    {
        exist = false;
        if (flag)
        {   
            foreach (GameObject t in Tiles)
            {
                if (t.transform.position == tilepos)
                {
                    exist = true;

                }

            }
            if (exist)
            {
                anim.Play("JumpingBob");
                arrangePos(direccion);
                mover = true;
                if (text != null)
                {
                    Turns--;
                    text.text = Turns + "";
                }
                


            }
            else
            {
                print("no hay nada");
            }
            flag = false;
        }
    }
    private void Down()
    {
        if (tmrflag && Time.timeScale != 0)
        {
            flag = true;
            Invoke("cooldown", .2f);
            tmrflag = false;
        }
    }
    private void cooldown()
    {
        tmrflag = true;
    }
    // Update is called once per frame
    void Update () {
        if (text != null)
        {
            Turns = int.Parse(text.text);
        }
            
        if(!mover)
        Swiper();
        if ((cubo.transform.position != cubopos) && mover)
        {
            cubo.transform.position = Vector3.MoveTowards(cubo.transform.position, cubopos, 9 * Time.deltaTime);

        }
        else
        {
            mover = false;
        }
    }


    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Swiper()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            Down();
            cubopos = cubo.transform.position;
            tilepos = cubopos;
            tilepos.y -= high;
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {   
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > 0)
                
            {
                print("up swipe");
                arrangeTilePos("Arriba");
                move("Arriba");
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x < 0 )
        {
                Debug.Log("down swipe");
                arrangeTilePos("Abajo");
                move("Abajo");
            }
            //swipe right
            if (currentSwipe.y < 0 && currentSwipe.x > 0 ) 
        {
                Debug.Log("right swipe");
                arrangeTilePos("Derecha");
                move("Derecha");
            }
            //swipe left
            if (currentSwipe.y > 0 && currentSwipe.x < 0)
            {
                
                Debug.Log("left swipe");
                arrangeTilePos("Izquierda");
                move("Izquierda");
            }
        }
    }

}
