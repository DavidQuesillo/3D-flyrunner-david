using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private int targetAmount = 1;
    [SerializeField] private float timerToVanish = 30f;
    private float startingTime;
    [SerializeField] private GameObject[] targets = new GameObject[1];

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.instance.targetsDisplay.text = timerToVanish.ToString(@"mm\:ss");
        targetAmount = targets.Length;
        startingTime = timerToVanish;
        StartCoroutine(CountTimerDown());
    }

    // Update is called once per frame
    void Update()
    {
        //UiManager.instance.SetTimerText(TimeSpan.FromSeconds(timerToVanish).ToString("mm:ss"));
        /*var ts = TimeSpan.FromSeconds(timerToVanish);
        UiManager.instance.SetTimerText(sting.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds));*/
        //timerToVanish -= Time.deltaTime;

    }

    public void TargetDestroyed()
    {
        targetAmount -= 1;
        GameManager.instance.targetsDisplay.text = targetAmount.ToString();
        if (targetAmount <= 0)
        {
            GameManager.instance.TargetsGone();
        }
    }

    public IEnumerator CountTimerDown()
    {
        while (timerToVanish > 0f)
        {
            UiManager.instance.SetTimerText(timerToVanish.ToString("f0"));
            UiManager.instance.VisualTimer(timerToVanish / startingTime);
            timerToVanish -= 1f;
            yield return new WaitForSeconds(1f);
        }
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }
    }
}
