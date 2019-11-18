using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    [SerializeField]
    private CameraMovement cameraMovement;

    private Point vortexSpawnLoc, phantomSpawnLoc;
    [SerializeField]
    private GameObject vortexSpawnPrefab;
    [SerializeField]
    private GameObject phantomSpawnPrefab;
    [SerializeField]
    private Transform map;


    public Dictionary<Point, TileScript> Tiles { get; set; }

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        Vector3 botRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
        int gridWidth = (int) ((botRight.x - topLeft.x) / TileSize) + 1;
        int gridHeight = (int)((topLeft.y - botRight.y) / TileSize) + 1;
        for (int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                PlaceTile(x, y, topLeft);
            }
        }

        Vector3 maxTile = Tiles[new Point(gridWidth - 1, gridHeight - 1)].transform.position;

        cameraMovement.SetLimits(new Vector3(maxTile.x + TileSize/2, maxTile.y - TileSize/2));
        PlaceSpawner();
    }

    private void PlaceTile(int x, int y, Vector3 topLeft)
    {
        TileScript newTile = Instantiate(tilePrefabs[0]).GetComponent<TileScript>();
        newTile.GetComponent<TileScript>().Setup(new Point(x, y), 
                                                 new Vector3(topLeft.x + TileSize * x + TileSize / 2, topLeft.y - TileSize * y - TileSize / 2, 0.0f),
                                                 map);
    }

    private void PlaceSpawner()
    {
        vortexSpawnLoc = new Point(0, 0);
        Instantiate(vortexSpawnPrefab, Tiles[vortexSpawnLoc].GetComponent<TileScript>().WorldPos, Quaternion.identity);
    }
}
