using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private Image HpFill;
    [SerializeField] private Text timerTxt;
    [SerializeField] private GameObject gameOverCanvas;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUiHP(float newValue)
    {
        HpFill.fillAmount = newValue / 100f;
    }
    
    public void SetTimerText(string timer)
    {
        timerTxt.text = timer;
    }

    public void DisplayGameOver()
    {
        gameOverCanvas.SetActive(true);
    }
}
