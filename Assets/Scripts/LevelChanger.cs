using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public Text text;
    public GameObject night;
    public GameObject transitionPanel;

    private int levelToLoad;
    private bool isDay;
    private int num = 1;
    private int checkIsDay;

    // Start is called before the first frame update
    void Start()
    {
        isDay = DayNightSingleton.Instance.getIsDay;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            levelToLoad = 0;
        } else
        {
            levelToLoad = 1;
            SetText();
        }

        if (!isDay && SceneManager.GetActiveScene().buildIndex == 1)
        {
            LevelManager.Instance.DarkenLevel();
            Debug.Log("Activating darkness");
           // night.SetActive(true);

        } else if (isDay && SceneManager.GetActiveScene().buildIndex == 1)
        {
            LevelManager.Instance.LightenLevel();
            Debug.Log("Deactivating darkness");
           // night.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            FadeToLevel(levelToLoad);
        }
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;

        if (levelIndex == 0)
        {
            DayNightSingleton.Instance.ToTransition();
        }
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
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
        }
        num ++;

    }




}
