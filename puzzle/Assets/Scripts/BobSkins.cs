using UnityEngine;
using System.Collections;

public class BobSkins : MonoBehaviour {
    private string skin;
    public Sprite front, back;
    public Sprite normal, normalb;
    public float x, y;
    private Vector3 origen;
    private bool flag = true;
	// Use this for initialization
	void Start () {
        origen.x = x;
        origen.y = y;
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

    void Update()
    {
        if (flag) 
        this.transform.position = Vector3.MoveTowards(this.transform.position, origen, 11 * Time.deltaTime);

        if (this.transform.position == origen)
            flag = false;
    }
	
	
}
