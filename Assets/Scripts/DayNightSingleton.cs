using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Allows us to use SceneManager

public class DayNightSingleton : MonoBehaviour
{
    // Singleton instance
    private static DayNightSingleton _instance;

    private int numDays = 0;
    private bool isDay = true;

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

    void ToTransition()
    {
        isDay = !isDay;
        if (isDay)
        {
            numDays++;
        }

        SceneManager.LoadScene("TransitonScreen");
    }
}
