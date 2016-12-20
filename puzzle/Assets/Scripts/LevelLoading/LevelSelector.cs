using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour {

    public string lvlName;
    private LevelLoader lvlLoader;
    private GameObject buttonSelector;
    

	// Use this for initialization
	void Start () {
        lvlLoader = GameObject.Find("LvlSelectButton").GetComponent<LevelLoader>();
        buttonSelector = GameObject.FindWithTag("Bob");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(lvlName);
        lvlLoader.setLevelName(lvlName);
        if (lvlName != "")
        {
            buttonSelector.GetComponent<HideButtonSelector>().enableLoader();
        }else
        {
            buttonSelector.GetComponent<HideButtonSelector>().disableLoader();
        }
            
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
