using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject settings,pause,play, home,restart,levels;
	// Use this for initialization
	void Start () {
        settings.SetActive(false);
        play.SetActive(false);
        home.SetActive(false);
        restart.SetActive(false);
        levels.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
	
    public void OnPause()
    {

        pause.SetActive(false);
        settings.SetActive(true);
        play.SetActive(true);
        home.SetActive(true);
        restart.SetActive(true);
        levels.SetActive(true);
        Time.timeScale = 0;
    }

	public void OnPlay()
    {
        pause.SetActive(true);
        settings.SetActive(false);
        play.SetActive(false);
        home.SetActive(false);
        restart.SetActive(false);
        levels.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }


}
