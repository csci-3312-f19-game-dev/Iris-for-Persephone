using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Allows us to use SceneManager

public class DayNightSingleton : MonoBehaviour
{
    // Singleton instance
    private static DayNightSingleton _instance;

    private int numDays = 1;
    private bool isDay = true;
    private int checkIsDay;

    public static DayNightSingleton Instance { get { return _instance; } }

    private void Awake()
        {
            // Singleton initialization.
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

    public int getNumDays { get { return numDays; } }

    public bool getIsDay { get { return isDay; } }

    public void ToTransition()
    {
        isDay = !isDay;
        if (isDay)
        {
            numDays++;
        }
        SceneManager.LoadScene(0);
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("day", numDays);
        if (isDay) {PlayerPrefs.SetInt("checkIsDay", 1);}
        else {PlayerPrefs.SetInt("checkIsDay", 0);}

    }

    void OnEnable()
    {
        numDays  =  PlayerPrefs.GetInt("day");
        checkIsDay  =  PlayerPrefs.GetInt("checkIsDay");
        if(checkIsDay == 1) {isDay = true;}
        else {isDay = false;}
    }

    void OnApplicationQuit()
    {
        isDay = true;
        numDays = 1;
    }
}
