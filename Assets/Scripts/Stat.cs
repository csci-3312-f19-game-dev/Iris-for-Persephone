using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content;
    private float currentFill;
    private float maxValue { get; set; }
    public float CurrentValue
    {
        get
        {
            return currentFill;
        }
        set
        {
            if(value > maxValue)
            {
                currentValue = maxValue;
            }
        }
    }

    private float currentValue;
    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
        content.fillAmount = 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
