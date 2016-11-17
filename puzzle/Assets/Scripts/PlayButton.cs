using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public void GoToLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

}
