using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }

    public bool IsEmpty { get; private set; }

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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (!EventSystem.current.IsPointerOverGameObject() &&
            GameManager.Instance.ClickedButton != null)
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

    private void OnMouseExit()
    {
        ColorTile(Color.white);
    }

    private void PlacePlant()
    {
        GameObject plant = Instantiate(GameManager.Instance.ClickedButton.PlantPrefab, transform.position, Quaternion.identity);
        plant.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;
        plant.transform.SetParent(transform);
        IsEmpty = false;
        ColorTile(Color.white);
        GameManager.Instance.BuyPlant();
    }

    private void ColorTile(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
