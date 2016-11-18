using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

    float timeLeft = 0f;
    int time;

    void Start()
    {
        this.GetComponent<Text>().text = timeLeft + "";
    }

    void Update()
    {
        timeLeft += Time.deltaTime;
        time = (int)timeLeft;
        this.GetComponent<Text>().text = time + "";
        if (timeLeft < 0)
        {
            print("hola");
        }
    }

}
