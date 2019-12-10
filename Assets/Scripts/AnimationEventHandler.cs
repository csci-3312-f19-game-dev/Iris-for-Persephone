using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEventHandler : MonoBehaviour
{
    public GameObject transitionPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFadeOutComplete () {
        transitionPanel.SetActive(true);
    }

    public void OnFadeInComplete() {
        transitionPanel.SetActive(false);
    }

}
