using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroButtons : MonoBehaviour
{
    public Button btnLevel1;
    public Button btnLevel2;
    // Start is called before the first frame update
    void Start()
    {
        btnLevel1.onClick.AddListener(() => ChangeScene("Level1"));
        btnLevel2.onClick.AddListener(() => ChangeScene("Level2"));
    }

    void ChangeScene(string levelNumber) {
        switch(levelNumber) {
            case "Level1":
                SceneManager.LoadScene("Level 1");
                break;
            case "Level2":
                SceneManager.LoadScene("Level 2");
                break;
            default:
                SceneManager.LoadScene("Intro");
                break;
        }
    }
}
