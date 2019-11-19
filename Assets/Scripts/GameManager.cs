using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public PlantButton ClickedButton { get; set; }

    private int seeds;

    private bool isNight = false;

    [SerializeField]
    private Text seedsText;
    private int numberOfEnemies;
    public int NumberOfEnemies
    {
        get
        {
            return numberOfEnemies;
        }
        set
        {
            this.numberOfEnemies = value;
            if(NumberOfEnemies == 0)
            {
                TransitionToDay();
            }
        }
    }

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

    public EnemyGenerator EnemyGen { get; set; }
    public bool IsNight { get => isNight; private set => isNight = value; }

    private void Awake()
    {
        EnemyGen = GetComponent<EnemyGenerator>();
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
        if (Seeds >= plantButton.Price)
        {
            this.ClickedButton = plantButton;
            Hover.Instance.Activate(plantButton.Sprite);
        }
    }

    public void BuyPlant()
    {
        if (Seeds >= ClickedButton.Price)
        {
            Seeds -= ClickedButton.Price;
            Hover.Instance.Deactivate();
        }
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
        }
    }

    public void TransitionToNight()
    {
        IsNight = true;
        LevelManager.Instance.DarkenLevel();
        StartCoroutine(SpawnEnemies());
    }

    public void TransitionToDay()
    {
        IsNight = false;
        LevelManager.Instance.LightenLevel();
    }

    private IEnumerator SpawnEnemies()
    {
        Point topLeftLoc = new Point(0, 0);
        Point topRightLoc = new Point(LevelManager.Instance.GridWidth - 1, 0);
        Point botLeftLoc = new Point(0, LevelManager.Instance.GridHeight - 1);
        Point botRightLoc = new Point(LevelManager.Instance.GridWidth - 1, LevelManager.Instance.GridHeight - 1);
        int locationIndex = Random.Range(0, 4);
        Point spawnLocation = new Point();
        switch (locationIndex)
        {
            case 0:
                spawnLocation = topLeftLoc;
                break;
            case 1:
                spawnLocation = topRightLoc;
                break;
            case 2:
                spawnLocation = botLeftLoc;
                break;
            case 3:
                spawnLocation = botRightLoc;
                break;

        }
        GameObject enemy = EnemyGen.GetEnemy("Boar");
        enemy.GetComponent<EnemyMovement>().Setup(spawnLocation);

        yield return new WaitForSeconds(3.0f);
    }
}
