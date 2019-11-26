using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayNightSwitch : Singleton<DayNightSwitch>
{
    public Text text;
    public Button toTransitionButton, toGameButton;
    public GameObject transitionPanel, gardenPanel;

    private bool isDay, isTransitionPanel;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        isDay = false;
        num = 1;
        SetText();

        transitionPanel.SetActive(true);
        gardenPanel.SetActive(false);
        isTransitionPanel = true;

        toTransitionButton.onClick.AddListener(()=>switchPanel());
        toGameButton.onClick.AddListener(()=>switchPanel());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchPanel()
    {
        isTransitionPanel = !isTransitionPanel;

        if (isTransitionPanel)
        {
            SetText();
            transitionPanel.SetActive(true);
            gardenPanel.SetActive(false);
        } else
        {
            if (isDay) { toTransitionButton.interactable = true; }
            else { toTransitionButton.interactable = false; }
            transitionPanel.SetActive(false);
            gardenPanel.SetActive(true);
        }
    }

    public void OnFadeComplete ()
    {

    }

    void SetText()
    {
        isDay = !isDay;

        if (isDay)
        {
            text.text = ("Day " + num);
        } else
        {
            text.text = ("Night " + num);
            num ++;
        }
    }


}
