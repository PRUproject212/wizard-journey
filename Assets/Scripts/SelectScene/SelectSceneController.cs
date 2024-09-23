using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSceneController : MonoBehaviour
{
    [Header("Button")]
    public Button ReturnButton;
    public Button Level1Button;

    private void Start() {
        ReturnButton.onClick.AddListener(OnClickReturnButton);
        Level1Button.onClick.AddListener(OnClickLevel1Button);
    }

    private void OnClickReturnButton(){
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }

    private void OnClickLevel1Button(){
        SceneManager.LoadScene(Scenes.Level1.ToString());
    }


}
