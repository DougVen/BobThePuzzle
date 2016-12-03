using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelLoader : MonoBehaviour{

    private string lvlName;
    private GameObject cubo;
    private BoxCollider2D loadTrigger;

    // Use this for initialization
    void Start () {
     
        cubo = GameObject.FindGameObjectWithTag("Bob");
        loadTrigger = this.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setLevelName(string name)
    {
        lvlName = name;
    }

    void OnMouseDown()
    {
        loadLvel();
    }

    public void loadLvel()
    {
        print("load");
        SceneManager.LoadScene(lvlName);
    }
    void OnTrigger()
    {

    }
}
