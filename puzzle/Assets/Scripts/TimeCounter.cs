using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {
    public GameObject text;
    float timeLeft = 0f;
    int time;

    void Start()
    {
        text.GetComponent<TextMesh>().text = timeLeft + "";
    }

    void Update()
    {
        timeLeft += Time.deltaTime;
        time = (int)timeLeft;
        text.GetComponent<TextMesh>().text = time + "";
        if (timeLeft < 0)
        {
            print("hola");
        }
    }

}
