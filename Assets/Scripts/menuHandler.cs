using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuHandler : MonoBehaviour
{
    public Animator anim;
    public Button playButton, creditsButton;
    public Text highScore;
    public GameObject mainMenu, creditsScreen;

    // Start is called before the first frame update
    void Start()
    {

        mainMenu.SetActive(true);
        creditsScreen.SetActive(false);

        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);

        creditsButton.onClick.AddListener(()=>SwitchToCredits());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            anim.SetBool("hasClicked", true);
        }
    }

    void SwitchToCredits() {
        mainMenu.SetActive(false);
        creditsScreen.SetActive(true);
    }

    void SwitchToMain() {
        mainMenu.SetActive(true);
        creditsScreen.SetActive(false);

    }
}
