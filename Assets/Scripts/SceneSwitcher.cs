using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{

    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(()=>ChangeScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeScene()
    {
        Debug.Log("hello");
    }
}
