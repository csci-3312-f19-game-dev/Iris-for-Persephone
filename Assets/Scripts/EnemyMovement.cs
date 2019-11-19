using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    static public float speed = 1.0f;

    // Time when the movement started.
    private float startTime;
    private Point loc;

    // Start is called before the first frame update
    public void Setup(Point start)
    {
        speed += 0.1f;
        GameManager.Instance.NumberOfEnemies += 1;
        loc = start;
        applyLocation();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 1 / speed)
        {
            Point goal = LevelManager.Instance.IrisLocation;
            if (goal.X == loc.X && goal.Y == loc.Y)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                Point oldLoc = loc;
                int xDiff = goal.X - loc.X;
                int yDiff = goal.Y - loc.Y;
                int xDir = xDiff > 0 ? 1 : -1;
                int yDir = yDiff > 0 ? 1 : -1;

                if (xDiff == 0 && yDiff != 0)
                {
                    loc.Y += yDir;
                }
                else if (xDiff != 0 && yDiff == 0)
                {
                    loc.X += xDir;
                }
                else
                {
                    int xy = Random.Range(0, 2);
                    switch (xy)
                    {
                        case 0:
                            loc.X += xDir;
                            break;
                        case 1:
                            loc.Y += yDir;
                            break;
                    }
                }
                if (!LevelManager.Instance.Tiles[loc].IsEmpty)
                {
                    GameManager.Instance.NumberOfEnemies -= 1;
                    foreach (Transform child in LevelManager.Instance.Tiles[loc].transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    LevelManager.Instance.Tiles[loc].IsEmpty = true;
                    Destroy(this.gameObject);
                    loc = oldLoc;
                }
                else
                {
                    applyLocation();
                }

            }

            startTime = Time.time;
        }
    }

    private void applyLocation()
    {
        transform.position = LevelManager.Instance.pointToWorldSpace(loc);
    }

    void OnMouseDown()
    {
        GameManager.Instance.Seeds += 3;
        // this object was clicked - do something
        GameManager.Instance.NumberOfEnemies -= 1;
        Destroy(this.gameObject);
    }
}
