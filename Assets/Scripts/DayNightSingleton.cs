using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Allows us to use SceneManager

public class DayNight : MonoBehaviour
{
    // Singleton instance
    private static DayNight _instance;

    private int numDays;
    private bool isDay;

    public static DayNight Instance { get { return _instance; } }

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
}
