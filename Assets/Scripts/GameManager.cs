using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public PlantButton ClickedButton { get; set; }

    private int seeds;

    [SerializeField]
    private Text seedsText;

    public int Seeds
    {
        get
        {
            return seeds;
        }
        set
        {
            this.seeds = value;
            this.seedsText.text = value.ToString() + " <color=yellow>$</color>";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Seeds = 5;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void PickPlant(PlantButton plantButton)
    {
        this.ClickedButton = plantButton;
        Hover.Instance.Activate(plantButton.Sprite);
    }

    public void BuyPlant()
    {
        Hover.Instance.Deactivate();
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
        }
    }
}
