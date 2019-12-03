using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }

    public bool IsEmpty { get; set; }
    public int enemiesPresent { get; set; }

    private Color32 failColor = new Color32(255, 150, 150, 255);
    private Color32 successColor = new Color32(120, 255, 100, 255);

    private SpriteRenderer spriteRenderer;

    public Vector2 WorldPos
    {
        get
        {
            return new Vector2(transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x / 2, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y / 2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemiesPresent = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Darken()
    {
        spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f);
    }

    public void Lighten()
    {
        spriteRenderer.color = Color.white;
    }

    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        IsEmpty = true;
        transform.position = worldPos;
        this.GridPosition = gridPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {
        
        //tooltips go here
       
        
        
        if (!EventSystem.current.IsPointerOverGameObject() &&
            GameManager.Instance.ClickedButton != null)
        {
            if (!GameManager.Instance.IsNight)
            {
                if (IsEmpty)
                {
                    ColorTile(successColor);
                }
                else
                {
                    ColorTile(failColor);
                }
                if (IsEmpty && Input.GetMouseButtonDown(0))
                {
                    PlacePlant();
                }
            }
        }
    }

    private void OnMouseExit()
    {
        if (!GameManager.Instance.IsNight)
        {
            ColorTile(Color.white);
        }
        else
        {
            ColorTile(new Color(0.3f, 0.3f, 0.3f));
        }
    }

    private void PlacePlant()
    {
        GameObject plant = Instantiate(GameManager.Instance.ClickedButton.PlantPrefab, transform.position, Quaternion.identity);
        plant.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;
        plant.transform.SetParent(transform);
        plant.name = GameManager.Instance.ClickedButton.Name;
        plant.AddComponent<PlantTile>();
        IsEmpty = false;
        ColorTile(Color.white);
        GameManager.Instance.BuyPlant();
    }

    private void ColorTile(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
