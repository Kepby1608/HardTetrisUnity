using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisBlock : MonoBehaviour
{

    public Vector3 rotatoinPoint;
    private float previousTime;
    public static bool first = false;
    public static int height = 30;
    public static int width;
    private static Transform[,] grid4;
    public static int score = 0;
    public static int level = 1;
    public static int countOfBurnLines;
    public static float fallTime = 0.8f;
    public GameObject spawner;
    public int cordinateOfSpawnerX;
    public int cordinateOfSpawnerY;
    public static int burnLinesOnMove = 0;


    void Start()
    {
        if(!first)
        {
            width = Start_Scene.size;
            grid4 = new Transform[width, height];
            first = !first;
        }

        var Component = spawner.GetComponent<SpawnTetromino>();
        cordinateOfSpawnerX = (int) Component.transform.position.x;
        cordinateOfSpawnerY = (int) Component.transform.position.y;
    }

    void Update()
    {
        //движение влево
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        //движение вправо
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        //вращение
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotatoinPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotatoinPoint), new Vector3(0, 0, 1), -90);
            }
        }
        //движение вниз с ускорением
        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            //проверка на возможность движения
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid4();
                CheckForLines();

                this.enabled = false;
                //здесь проверка на переполнение верхнего спавна и конец игры
                foreach (Transform children in transform)
                {
                    if (grid4[cordinateOfSpawnerX-1, cordinateOfSpawnerY] != null
                        || cordinateOfSpawnerY == children.transform.position.y)
                    {
                        gameObject.transform.parent.GetComponent<GameOver>().over = true;
                    }
                }
                FindObjectOfType<SpawnTetromino>().NewTetromino();
            }
            previousTime = Time.time;
        }
    }

    float FallTime(int level)
    {
        return Mathf.Pow((float)(0.8 - ((level - 1) * 0.007)), (level));
    }

    void UpLevel()
    {
        if (countOfBurnLines % 2 == 0)
        {
            level++;
            fallTime = FallTime(level);
        }
    }
    void CheckForLines()
    {
        burnLinesOnMove = 0;
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                burnLinesOnMove++;
                DeleteLine(i);
                RowDown(i);

                countOfBurnLines++;
                UpLevel();
            }
        }

        if(burnLinesOnMove > 0)
        {
            score += (burnLinesOnMove * burnLinesOnMove * 100);
            //UpdateScore();
        }
    }

    bool HasLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            if(grid4[j, i] == null)
            {
                return false;
            }
        }

        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid4[j, i].gameObject);
            grid4[j, i] = null;
        }
        
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                if(grid4[j,y] != null)
                {
                    grid4[j, y - 1] = grid4[j, y];
                    grid4[j, y] = null;
                    grid4[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid4()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid4[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if(grid4[roundedX, roundedY] != null)
            {
                return false;
            }
        }

        return true;
    }
}
