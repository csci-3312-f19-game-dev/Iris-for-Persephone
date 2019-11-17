using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Allows us to use SceneManager


public class TransitionDaySet : MonoBehaviour
{
    int num;
    public Text text;


    // Start is called before the first frame update
    void Start()
    {

        num = DayNightSingleton.Instance.getNumDays;

        if (DayNightSingleton.Instance.getIsDay)
        {
            text.text = ("Day " + num);
        } else
        {
            text.text = ("Night " + num);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
