using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class CreditSwitcher : MonoBehaviour
{

    public Button button;
    public GameObject mainMenu, creditsScreen;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        creditsScreen.SetActive(false);
        button.onClick.AddListener(()=>Switcharoo());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Switcharoo()
    {

        mainMenu.SetActive(false);
        creditsScreen.SetActive(true);

    }
}
