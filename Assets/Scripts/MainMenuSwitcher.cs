using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class MainMenuSwitcher : MonoBehaviour
{

    public Button button;
    public GameObject mainMenu, creditsScreen;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
        creditsScreen.SetActive(true);
        button.onClick.AddListener(()=>Switcharoo());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Switcharoo()
    {

        mainMenu.SetActive(true);
        creditsScreen.SetActive(false);

    }
}
