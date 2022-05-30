using CollectRace;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public static GameManager instance;
    [Header("STATE")]
    public PlayerState playerState;
    public enum PlayerState  
    {
        Preparing,
        Playing,
        Finish,
        Failed,
    }
    private void Awake()
    {
        if (instance == null)
        {          
            instance = this;
        }
    }
    public void StartGame()
    {
        playerState = PlayerState.Playing;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        playerState = PlayerState.Preparing;
    }
}