using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayNightSwitch : Singleton<DayNightSwitch>
{
    public Text text;
    public Button toTransitionButton, toGameButton;
    public GameObject transitionPanel;
    public AudioSource audio;
    public AudioClip dayMusic, nightMusic;
    public Animator anim;
    public Image img;

    private bool isDay, isTransitionPanel;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        audio.clip = dayMusic;

        isDay = false;
        num = 1;
        SetText();

        ActivateTransitionIn();
        //transitionPanel.SetActive(true);
        isTransitionPanel = true;

        toTransitionButton.onClick.AddListener(()=>switchPanel());
        toGameButton.onClick.AddListener(()=>switchPanel());

        //StartCoroutine(ActivateTransitionIn());
        //StartCoroutine(ActivateTransitionOut());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchPanel()
    {
        isTransitionPanel = !isTransitionPanel;

        if (isTransitionPanel) {
            ActivateTransitionIn();
            SetText();
        }
        else {

            if (isDay) {
                ActivateTransitionOut();
                audio.clip = dayMusic;
                audio.Play();
                toTransitionButton.gameObject.SetActive(true);
            } else {
                ActivateTransitionOut();
                audio.clip = nightMusic;
                audio.Play();
                toTransitionButton.gameObject.SetActive(false);
            }
            //ActivateTransitionOut();
            //transitionPanel.SetActive(false);
        }
    }

    public void ActivateTransitionIn() {
        anim.SetBool("FadeOut", false);
        anim.SetBool("FadeIn", true);
        //yield return new WaitForSeconds(2);
    }
    public void ActivateTransitionOut() {
        anim.SetBool("FadeIn", false);
        anim.SetBool("FadeOut", true);
        //yield return new WaitForSeconds(2);
        //transitionPanel.SetActive(false);

    }

    public void KillThePanel() {
        transitionPanel.SetActive(false);
        //if (!isDay) { GameManager.Instance.TransitionToNight(); }
    }

    public void TrueRessurection() {
        //GameManager.Instance.TransitionToDay();
        transitionPanel.SetActive(true);
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
