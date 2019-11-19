using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    [SerializeField]
    private CameraMovement cameraMovement;

    [SerializeField]
    private Transform map;
    [SerializeField]
    private GameObject vortexSpawnPrefab;
    [SerializeField]
    private GameObject irisPrefab;

    private Point irisLocation;


    public Dictionary<Point, TileScript> Tiles { get; set; }

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    public int GridWidth
    {
        get {
            Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
            Vector3 botRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
            return (int)((botRight.x - topLeft.x) / LevelManager.Instance.TileSize) + 1;
        }
    }

    public int GridHeight
    {
        get
        {
            Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
            Vector3 botRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
            return (int)((topLeft.y - botRight.y) / TileSize) + 1;
        }
    }

    public Point IrisLocation { get => irisLocation; private set => irisLocation = value; }

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
        int gridWidth = GridWidth;
        int gridHeight = GridHeight;
        for (int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                PlaceTile(x, y, topLeft);
            }
        }

    
        Vector3 maxTile = Tiles[new Point(gridWidth - 1, gridHeight - 1)].transform.position;

        cameraMovement.SetLimits(new Vector3(maxTile.x + TileSize/2, maxTile.y - TileSize/2));

        // Iris
        IrisLocation = new Point((gridWidth - 1) / 2, (gridHeight - 1) / 2);
        Vector3 irisLoc = Tiles[IrisLocation].GetComponent<TileScript>().WorldPos;
        Instantiate(irisPrefab, new Vector3(irisLoc.x + TileSize / 2, irisLoc.y - TileSize / 2, 0.0f), Quaternion.identity);

        Point topLeftLoc = new Point(0, 0);
        Point topRightLoc = new Point(gridWidth - 1, 0);
        Point botLeftLoc = new Point(0, gridHeight - 1);
        Point botRightLoc = new Point(gridWidth - 1, gridHeight - 1);
        PlaceSpawner(topLeftLoc);
        PlaceSpawner(topRightLoc);
        PlaceSpawner(botLeftLoc);
        PlaceSpawner(botRightLoc);
    }

    public void DarkenLevel()
    {
        int gridWidth = GridWidth;
        int gridHeight = GridHeight;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Tiles[new Point(x, y)].Darken();
            }
        }
    }

    public void LightenLevel()
    {
        int gridWidth = GridWidth;
        int gridHeight = GridHeight;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Tiles[new Point(x, y)].Lighten();
            }
        }

    }
     
    public Vector3 pointToWorldSpace(Point p)
    {
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        return new Vector3(topLeft.x + TileSize * p.X + TileSize / 2, topLeft.y - TileSize * p.Y - TileSize / 2, 0.0f);
    }

    private void PlaceTile(int x, int y, Vector3 topLeft)
    {
        TileScript newTile = Instantiate(tilePrefabs[0]).GetComponent<TileScript>();
        newTile.GetComponent<TileScript>().Setup(new Point(x, y), 
                                                 new Vector3(topLeft.x + TileSize * x + TileSize / 2, topLeft.y - TileSize * y - TileSize / 2, 0.0f),
                                                 map);
    }

    private Vector3 orientTile(Vector3 pos)
    {
        return new Vector3(pos.x + TileSize / 2, pos.y - TileSize / 2, 0.0f);
    }

    private void PlaceSpawner(Point spawnLoc)
    {
        Vector3 pos = orientTile(LevelManager.Instance.Tiles[spawnLoc].GetComponent<TileScript>().WorldPos);
        Instantiate(vortexSpawnPrefab, pos, Quaternion.identity);
    }

    private Vector3 worldPositionFromPoint(Point x)
    {
        return Tiles[x].GetComponent<TileScript>().WorldPos;
    }

}
