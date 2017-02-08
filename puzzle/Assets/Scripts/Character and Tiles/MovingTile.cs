using UnityEngine;
using System.Collections;

public class MovingTile : MonoBehaviour {
    public Vector3 begin, end,extra1,extra2;// vectores de posicion
    private int max=1;
    private bool flag=true,bob=false;//flag para detener un rato
    public bool acte1, acte2;
    private int direct = 0;//1 se mueve para end, 0 para begin
    private GameObject cubo;

	void Start () {
        cubo = GameObject.FindGameObjectWithTag("Bob");
        if (acte1)
            max++;

        if (acte2)
            max++;
    }
	void Timer()
    {
        Invoke("activate", 1f);//timer en el que se detiene
    }

    void activate()
    {
        flag = true;
        
    }

    void align()
    {
        Vector3 here = this.transform.position;
        here.y += 0.5f;
        cubo.transform.position = here;
    }
    void towards(Vector3 vec,int num)
    {
        if (direct == num)
            this.transform.position = Vector3.MoveTowards(transform.position, vec, 2 * Time.deltaTime);

    }
    
    void check(Vector3 vec)
    {
        if (transform.position == vec)
        {
            flag = false;
            direct++;
            if (direct > max)
                direct = 0;
            if (bob)
                align();
            bob = false;
            Timer();
        }
    }
    // Update is called once per frame
    void Update () {
        Vector3 cubopos = cubo.transform.position;
        cubopos.y -= 0.5f;

        if (flag) {

            if (cubopos == this.transform.position)
                bob = true;

            if (bob)
            {
                align();
            }


            towards(end, 0);
            towards(begin, 1);
            if (acte1)
                towards(extra1, 2);
            if (acte2)
                towards(extra2, 3);
            check(end);
            check(begin);
            if (acte1)
                check(extra1);
            if (acte2)
                check(extra2);

        }
    }
}
