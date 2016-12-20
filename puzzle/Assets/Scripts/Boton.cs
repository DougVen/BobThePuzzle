using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : MonoBehaviour {
    public string currentLevel;
	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
