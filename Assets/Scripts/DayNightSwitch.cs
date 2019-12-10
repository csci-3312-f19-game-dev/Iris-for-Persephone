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

    public bool isDay;
    private bool isTransitionPanel;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        audio.clip = dayMusic;

        isDay = false;
        num = 1;
        SetText();

        ActivateTransitionIn();
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

        if (isTransitionPanel) {
            ActivateTransitionIn();
            SetText();
            SetDayNight();
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
        //anim.SetBool("FadeOut", false);
        //anim.SetBool("FadeIn", true);
        anim.Play("Fade_In", 0, 0f);
        //yield return new WaitForSeconds(2);
    }
    public void ActivateTransitionOut() {
        //anim.SetBool("FadeIn", false);
        //anim.SetBool("FadeOut", true);
        anim.Play("Fade_Out", 0, 0f);
        //yield return new WaitForSeconds(2);
        //transitionPanel.SetActive(false);

    }

    public void SetDayNight() {
        if (isDay) { LevelManager.Instance.LightenLevel(); }
        else { LevelManager.Instance.DarkenLevel(); }
    }

    public void KillThePanel() {
        if (!isDay) { GameManager.Instance.TransitionToNight(); }
        transitionPanel.SetActive(false);
    }

    public void TrueRessurection() {
        //GameManager.Instance.TransitionToDay();
        transitionPanel.SetActive(true);
    }

    void SetText()
    {
        isDay = !isDay;

        if (isDay) { text.text = ("Day " + num); }
        else {
            text.text = ("Night " + num);
            num ++;
        }
    }

}
