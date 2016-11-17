using UnityEngine;
using System.Collections;

public class BobSkins : MonoBehaviour {
    private string skin;
    public Sprite front, back;
    public Sprite normal, normalb;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("Skin", "Normal");
        skin=PlayerPrefs.GetString("Skin");

        switch (skin) 
        {
            case "Normal":
                front = normal;
                back = normalb;
                break;
            default:
                front = normal;
                back = normalb;
                break;

        }
	}
	
	
}
