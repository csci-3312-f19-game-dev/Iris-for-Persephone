using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButtons : MonoBehaviour
{
    public Button playButton, creditsButton;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableTheButtons() {
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);
    }

    public void DisableTheButtons() {
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
    }
}
