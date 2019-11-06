using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantScript : MonoBehaviour
{

    Renderer plant_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        plant_Renderer = GetComponent<Renderer>();
        plant_Renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseOver()
    {
      if(Input.GetMouseButtonDown(1)) {
        plant_Renderer.enabled = true;
      }

    }
}
