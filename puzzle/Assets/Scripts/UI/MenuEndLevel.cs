using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEndLevel : MonoBehaviour {
    private Canvas CoinMenu, GoMenu;
    public Text plus2;
    private Image bronze, silver, gold;
    private bool flag = false,flag2=true;
    public int bronzetime, silvertime, goldtime;
    public Sprite vacio;
    private float launchfx;
    private GameObject GameTime;
    private int WinTime;
    public GameObject Win;
    // Use this for initialization
    void Start() {
        launchfx = 0.3f;
        //hago invisible las monedas
        Canvas[] C = Win.GetComponentsInChildren<Canvas>();
        CoinMenu = C[0];
        GoMenu = C[1];

        Image[] Medals = CoinMenu.GetComponentsInChildren<Image>();
        bronze = Medals[1];
        silver = Medals[2];
        gold = Medals[3];

        bronze.enabled = false;
        silver.enabled = false;
        gold.enabled = false;
        GameTime = GameObject.FindGameObjectWithTag("Timer");
        

    }

    // Update is called once per frame
    void Update() {
        if (flag) { 
        GoMenu.transform.position = Vector3.MoveTowards(GoMenu.transform.position, new Vector3(0, 0, 0), 60 * Time.deltaTime);
            Invoke("Hide", 0.7f);
        }
       
        if (flag2&&CoinMenu.enabled)
        {
            WinTime = int.Parse(GameTime.GetComponent<Text>().text.ToString());
            print(WinTime);
            if (WinTime > bronzetime)
            {   
                bronze.sprite = vacio;
                silver.sprite = vacio;
                gold.sprite = vacio;
                bronze.GetComponentInChildren<Text>().enabled= false;
                silver.GetComponentInChildren<Text>().enabled = false;
                gold.GetComponentInChildren<Text>().enabled = false;

                PlayerPrefs.SetInt("PlayerCoins", PlayerPrefs.GetInt("PlayerCoins") +2 );
            }
            else if(WinTime >silvertime)
            {
                silver.sprite = vacio;
                gold.sprite = vacio;
                PlayerPrefs.SetInt("PlayerCoins", PlayerPrefs.GetInt("PlayerCoins") + 3);

                plus2.GetComponent<Text>().enabled = false;
                silver.GetComponentInChildren<Text>().enabled = false;
                gold.GetComponentInChildren<Text>().enabled = false;

            }
            else if (WinTime > goldtime)
            {
                gold.sprite = vacio;
                PlayerPrefs.SetInt("PlayerCoins", PlayerPrefs.GetInt("PlayerCoins") + 5);
                plus2.GetComponent<Text>().enabled = false;
                bronze.GetComponentInChildren<Text>().enabled = false;
                gold.GetComponentInChildren<Text>().enabled = false;
            }
            else
            {
                PlayerPrefs.SetInt("PlayerCoins", PlayerPrefs.GetInt("PlayerCoins") + 10);
                plus2.GetComponent<Text>().enabled = false;
                bronze.GetComponentInChildren<Text>().enabled = false;
                silver.GetComponentInChildren<Text>().enabled = false;
            }
            Invoke("appearBronze", launchfx);
            Invoke("appearSilver", launchfx*2);
            Invoke("appearGold", launchfx*3);

            flag2 = false;
            

        }

    }

    private void appearGold()
    {
        gold.enabled = true;
    }
    private void appearSilver()
    {
        silver.enabled = true;
    }
    private void appearBronze()
    {
        bronze.enabled = true;
    }



    public void LevelMenu()
    {
        flag = true;
    }

    public void home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void nextlevel()
    {

    }

    private void Hide()
    {
        CoinMenu.enabled = false;
    }


}
