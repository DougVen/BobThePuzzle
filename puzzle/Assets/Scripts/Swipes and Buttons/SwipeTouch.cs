using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwipeTouch : MonoBehaviour
{
    private int Turns;
    public Text text;
    private GameObject cubo;
    private GameObject[] Tiles;
    private Sprite front, back;
    Vector3 cubopos, tilepos, winningpos;
    public float dx, dy,high;
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
    // Update is called once per frame
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
    void Update()
    {
        if(text != null)
            Turns = int.Parse(text.text);
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

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Swiper()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                Down();
                cubopos = cubo.transform.position;
                tilepos = cubopos;
                tilepos.y -= high;
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

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
                if (currentSwipe.y < 0 && currentSwipe.x < 0)
                {
                    Debug.Log("down swipe");
                    arrangeTilePos("Abajo");
                    move("Abajo");
                }
                //swipe right
                if (currentSwipe.y < 0 && currentSwipe.x > 0)
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
}
