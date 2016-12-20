using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour {
    public Text coins;
    private int coinnum;
	// Use this for initialization
	void Start () {
        
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            coinnum = PlayerPrefs.GetInt("PlayerCoins");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerCoins", 0);
            coinnum = 0;
        }
           
        coins.text = "" + coinnum;

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Play()
    {

        SceneManager.LoadScene("LevelSelect");
    }
}
