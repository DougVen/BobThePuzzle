using UnityEngine;
using System.Collections;

public class TimerButtonTile : MonoBehaviour {

    public GameObject wonder;
    private GameObject cubo;
    public float Tmr;
    private bool flag = false;
    public Vector3 restart;
    // Use this for initialization
    void Start()
    {
        cubo = GameObject.FindGameObjectWithTag("Bob");

    }
    public void Timer()
    {
        Invoke("off", Tmr);
    }

    private void off()
    {
        wonder.GetComponent<WonderTile>().Setobs(false);
        Vector3 cubopos = cubo.transform.position;
        cubopos.y -= 0.5f;
        if (wonder.transform.position == cubopos)
        {
            cubo.transform.position = restart;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 hey = cubo.transform.position;
        hey.y -= 0.5f;
        if (hey == this.transform.position)
        {
            wonder.GetComponent<WonderTile>().Setobs(true);
            this.GetComponentsInChildren<SpriteRenderer>()[2].enabled = true;
            this.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
            flag = true;
            
        }
        if (hey != this.transform.position && flag)
        {
            Timer();
            flag = false;
        }
            
    }
}
