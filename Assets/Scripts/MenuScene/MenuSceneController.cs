using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    [Header("Button")]
    public Button PlayButton;
    public Button CreditButton;
    public Button ExitButton;
    public Button ShopButton;
    public Button LevelSelectButton;

    [Header("Pop up")]
    public GameObject CreditPopUp;
    [SerializeField] private GameObject shopPopup;
    [SerializeField] private GameObject levelPopup;

    void Start() {
        PlayButton.onClick.AddListener(OnClickPlayButton);
        CreditButton.onClick.AddListener(OnClickCreditButton);    
        ExitButton.onClick.AddListener(OnClickExitButton);
        ShopButton.onClick.AddListener(OnClickShopButton);
        LevelSelectButton.onClick.AddListener(OnClickLevelSelectButton);
    }

    private void OnClickPlayButton()
    {
        SceneManager.LoadScene(Scenes.Level1.ToString()); // switch sceen 1
    }

    private void OnClickCreditButton()
    {
        CreditPopUp.SetActive(true);
    }

    private void OnClickExitButton()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void OnClickShopButton()
    {
        shopPopup.gameObject.SetActive(true); //
    }

    private void OnClickLevelSelectButton()
    {
        levelPopup.gameObject.SetActive(true); // 
    }
}
