using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    [Header("Button")]
    public Button PlayButton;
    public Button CreditButton;
    public Button ExitButton;
    public Button LevelSelectButton;

    [Header("Pop up")]
    public GameObject CreditPopUp;
    [SerializeField] private GameObject shopPopup;
    [SerializeField] private GameObject levelPopup;

    [Header("Hold Logic Settings")]
    public float holdDuration = 1.0f; // Time required to hold the button (in seconds)

    private bool isHoldingPlayButton = false;
    private bool isHoldingCreditButton = false;
    private float holdTimer = 0;

    void Start()
    {
        // Attach functions to button events
        PlayButton.onClick.AddListener(() => StartCoroutine(HoldButton(OnClickPlayButton, PlayButton)));
        CreditButton.onClick.AddListener(() => StartCoroutine(HoldButton(OnClickCreditButton, CreditButton)));
        ExitButton.onClick.AddListener(OnClickExitButton);
        LevelSelectButton.onClick.AddListener(() => StartCoroutine(HoldButton(OnClickLevelSelectButton, LevelSelectButton)));
    }

    private void Update()
    {
        // You can update hold logic here if necessary for other continuous actions
    }

    private IEnumerator HoldButton(System.Action action, Button button)
    {
        float holdTime = 0f;
        while (holdTime < holdDuration)
        {
            if (!Input.GetMouseButton(0)) // Check if the button is released before the required hold time
            {
                yield break; // Exit the coroutine if button is released early
            }

            holdTime += Time.deltaTime;
            yield return null;
        }

        // Action happens only if the button is held for the required duration
        action.Invoke();
    }

    private void OnClickPlayButton()
    {
        SceneManager.LoadScene("Level1"); // Assuming SceneManager loads a scene by name
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
        shopPopup.SetActive(true); // Open shop pop-up on hold
    }

    private void OnClickLevelSelectButton()
    {
        levelPopup.SetActive(true); // Open level select pop-up on hold
    }
}
