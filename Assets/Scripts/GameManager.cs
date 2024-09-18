using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text subTitle;

    public Button restartButton;
    public Button continueButton;
    public Button backToHomeButton;

    private GameOver gameOverInstance;
    private void Start() {
        title.gameObject.SetActive(false);
        subTitle.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        backToHomeButton.gameObject.SetActive(false);
        
        
        restartButton.onClick.AddListener(gameOverInstance.RestartLevel);
        backToHomeButton.onClick.AddListener(gameOverInstance.BackToHome);
        continueButton.onClick.AddListener(gameOverInstance.ContinueLevel);
    }
    public void Result(string result) {
        switch(result){

            case "Game Over" :
                title.gameObject.SetActive(true);title.SetText("Game Over");
                subTitle.gameObject.SetActive(true);subTitle.SetText("Please try again");
                restartButton.gameObject.SetActive(true);
                backToHomeButton.gameObject.SetActive(true);
                
                break;

            case "Success":
                title.gameObject.SetActive(true);title.SetText("Complete!");
                subTitle.gameObject.SetActive(true);subTitle.SetText("Let us continue");
                restartButton.gameObject.SetActive(true);
                backToHomeButton.gameObject.SetActive(true);
                continueButton.gameObject.SetActive(true);
                
                break;
        }
    }
}
