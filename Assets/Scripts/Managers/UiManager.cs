using CollectRace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoSingleton<UiManager>
{
    [SerializeField]
    private GameObject GameFailedPanel;
    [SerializeField]
    private GameObject GameSuccessPanel;
    [SerializeField]
    private GameObject GameStartPanel;
    [Header("STATE")]
    public Canvas canvas;
    public Sprite CurrentWinSprite;
    public static UiManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameStartPanel.SetActive(true);
    }
    void Update()
    {
        WinSprite();
    }

    void WinSprite() 
    {
        if (GameManager.instance.playerState == GameManager.PlayerState.Playing)
        {
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            CurrentWinSprite = ModelManager.Instance.ModelList[0].GetComponent<WinController>().WinSprite;
            canvas.transform.GetChild(1).GetComponent<Image>().sprite = CurrentWinSprite;
        }
        if (GameManager.instance.playerState == GameManager.PlayerState.Finish)
        {
            canvas.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void GameFailed() 
    {
        GameFailedPanel.SetActive(true);
        GameManager.Instance.playerState = GameManager.PlayerState.Preparing;
    }

    public void OnRestartGameClicked()
    {
        GameFailedPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.GetComponent<GameManager>().RestartGame();
        GameManager.Instance.playerState = GameManager.PlayerState.Playing;
    }

    public void OnNextLevelClicked()
    {
        GameSuccessPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.GetComponent<GameManager>().RestartGame();
        GameManager.Instance.playerState = GameManager.PlayerState.Playing;
    }

    public void OnStartClicked()
    {
        GameStartPanel.SetActive(false);
        GameManager.Instance.playerState = GameManager.PlayerState.Playing;
        GameManager.Instance.GetComponent<GameManager>().StartGame();
    }
}
