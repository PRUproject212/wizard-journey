using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UILevel1Controller : MonoBehaviour
{
    private static UILevel1Controller instance;

    public static UILevel1Controller Instance{
        get{
            if (instance == null) 
            {
                instance = FindObjectOfType<UILevel1Controller>(true);
            }
             return instance;
        }
    }

    private void Awake() {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    [Header("Button")]
    public Button PauseButton;
    public Button Level2Button;
    public Button RetryButton;
    public Button MenuButton;
    public Button CancelButton;

    [Header("Popup")]
    public GameObject GameOverPopup;
    public GameObject LevelCompletePopup;
    public GameObject FailPopup;
    public GameObject PausePopup;
      
    PlayerHealth playerHealth;

    private void Start() {
        PauseButton.onClick.AddListener(() =>
        {
            Debug.Log("pausing");
            PausePopup.SetActive(true);
            Time.timeScale = 0f;
        });

        CancelButton.onClick.AddListener(() =>
        {
            Debug.Log("resuming");

            PausePopup.SetActive(false);
            Time.timeScale = 1f;
        });

        Level2Button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Scenes.Level2.ToString());
            Time.timeScale = 1f;
        });

        RetryButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            GameManager.Instance.ResetHealth();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        MenuButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            GameManager.Instance.ResetHealth();
            SceneManager.LoadScene(Scenes.MenuScene.ToString());
        });

        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnClickGameOverButton(){
        GameOverPopup.SetActive(true);
    }

    private void OnClickLevelCompleteButton(){
        LevelCompletePopup.SetActive(true);
    }

    public void OnClickRestartButton(){
        Time.timeScale = 1f;
        GameManager.Instance.ResetHealth();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickMenuButton(){
        Time.timeScale = 1f;
        Debug.Log("void onclickmenu");
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }

    public void OnClickCancelPopupButton()
    {

        PausePopup.SetActive(false);
        LevelCompletePopup.SetActive(false);
        GameOverPopup.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickSoundButton(){

    }

    public void OnClickMusicButton(){
        
    }
}
