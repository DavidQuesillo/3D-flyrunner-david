using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private Image HpFill;
    [SerializeField] private Text timerTxt;
    [SerializeField] private Image timerFill;
    [SerializeField] private GameObject gameOverCanvas;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    private void OnEnable()
    {
        GameManager.OnGameStageChange += GameManager_OnGameStageChange;
    }

    private void OnDisable()
    {
        GameManager.OnGameStageChange -= GameManager_OnGameStageChange;
    }

    private void GameManager_OnGameStageChange(EGameStates newGameState)
    {
        switch (newGameState)
        {
            case EGameStates.Gameplay:
                break;
            case EGameStates.Restart:
                DisplayGameOver(false);
                break;
            case EGameStates.GameOver:
                break;
        }
    }

    public void UpdateUiHP(float newValue)
    {
        HpFill.fillAmount = newValue / 100f;
    }
    
    public void SetTimerText(string timer)
    {
        timerTxt.text = timer;
    }
    public void VisualTimer(float amount)
    {
        timerFill.fillAmount = amount;
    }

    public void DisplayGameOver(bool show = true)
    {
        gameOverCanvas.SetActive(show);
    }
}