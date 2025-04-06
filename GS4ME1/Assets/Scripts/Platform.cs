using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    
    public GameObject Cell;
    public GameObject Cell2;
    public int xSize, ySize;
    public float Scale;
    public int randomNum;
    public GameObject[,] arrCells;
    public bool[,] arrMines;
    public int[,] arrMinePerimeter;
    public Slider slider;
    public Vector3 Coordinates;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
        
       
        Scale = slider.value;
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                arrCells[j,i].transform.localScale = new Vector3(Scale, Scale, Scale);
                arrCells[j, i].transform.localPosition = new Vector3((hits[0].pose.position.x + (j*1.5f)) *Scale, 0,(hits[0].pose.position.z + (i*1.5f))*Scale);
            }
        }
    }

    int CountMines(int j, int i)
    {
        int mineCount = 0;
        if (j == 0 && i == 0)
        {
            if (arrMines[j + 1, i])
            {
                mineCount++;
            }

            if (arrMines[j, i + 1])
            {
                mineCount++;
            }

            if (arrMines[j + 1, i + 1] )
            {
                mineCount++;
            }
        }
        else if (j == 0 && i > 0 && i < ySize - 1)
        {
            if (arrMines[j,i-1])
            {
                mineCount++;
            }

            if (arrMines[j + 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i])
            {
                mineCount++;
            }

            if (arrMines[j, i + 1])
            {
                mineCount++;
            }

            if (arrMines[j + 1, i + 1])
            {
                mineCount++;
            }
        }
        else if (j == 0 && i == ySize - 1)
        {
            if (arrMines[j,i-1])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i])
            {
                mineCount++;
            }
        }
        else if (j == xSize - 1 && i == 0)
        {
            if (arrMines[j - 1, i])
            {
                mineCount++;
            }
            if (arrMines[j - 1, i + 1])
            {
                mineCount++;
            }
            if (arrMines[j, i + 1] )
            {
                mineCount++;
            }
        }
        else if (j == xSize - 1 && i > 0 && i < ySize - 1)
        {
            if (arrMines[j - 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j,i-1])
            {
                mineCount++;
            }
            if (arrMines[j - 1, i])
            {
                mineCount++;
            }
            if (arrMines[j - 1, i + 1])
            {
                mineCount++;
            }
            if (arrMines[j, i + 1] )
            {
                mineCount++;
            }
        }
        else if (j == xSize - 1 && i == ySize - 1)
        {
            if (arrMines[j - 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j,i-1])
            {
                mineCount++;
            }
            if (arrMines[j - 1, i])
            {
                mineCount++;
            }
        }
        else if (j > 0 && j < xSize - 1 && i == 0)
        {
            if (arrMines[j - 1, i])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i] )
            {
                mineCount++;
            }
            if (arrMines[j - 1, i + 1])
            {
                mineCount++;
            }
            if (arrMines[j, i + 1])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i + 1] )
            {
                mineCount++;
            }
        }
        else if (j > 0 && j < xSize - 1 && i > 0 && i < ySize - 1)
        {
            if (arrMines[j - 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j,i-1])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j - 1, i])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i] )
            {
                mineCount++;
            }
            if (arrMines[j - 1, i + 1])
            {
                mineCount++;
            }
            if (arrMines[j, i + 1])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i + 1] )
            {
                mineCount++;
            }
        }
        else if (j > 0 && j < xSize - 1 && i == ySize - 1)
        {
            if (arrMines[j - 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j,i-1])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i - 1])
            {
                mineCount++;
            }
            if (arrMines[j - 1, i])
            {
                mineCount++;
            }
            if (arrMines[j + 1, i] )
            {
                mineCount++;
            }
        }

        return mineCount;
    }

    public void CreateMines()
    {
        hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width/2,Screen.height/2), hits,
            UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        if (hits.Count > 0)
        {
            randomNum = Random.Range(10, 15);
            xSize = randomNum;
            ySize = randomNum;
            arrCells = new GameObject[xSize, ySize];
            arrMines = new bool[xSize,ySize];
            arrMinePerimeter = new int[xSize,ySize];
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    arrCells[j, i] = Instantiate(Cell, new Vector3((hits[0].pose.position.x + (j*1.5f)) * Scale, 0,(hits[0].pose.position.z + (i*1.5f)) * Scale), Quaternion.identity);
                    arrCells[j, i].transform.localScale = new Vector3(Scale, Scale, Scale);
                    randomNum = Random.Range(0, 100);
                    if (randomNum <=30)
                    {
                        arrCells[j,i].GetComponent<Cells>().type = Cells.Type.Mine;
                    }
                    if (arrCells[j, i].GetComponent<Cells>().type == Cells.Type.Mine)
                    {
                        arrMines[j, i] = true;
                    }
                
                }
            }

            for (int i = ((ySize / 2) - 1); i <= ((ySize / 2) + 1); i++)
            {
                for (int j = ((xSize / 2) - 1); j <= ((xSize / 2) + 1); j++)
                {
                    arrCells[j, i].GetComponent<Cells>().type = Cells.Type.Empty;
                }
            }
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    arrMinePerimeter[j, i] = CountMines(j,i);
                    if (arrMinePerimeter[j, i] > 0 && arrCells[j, i].GetComponent<Cells>().type != Cells.Type.Mine)
                    {
                        arrCells[j, i].GetComponent<Cells>().type = Cells.Type.Number;
                        arrCells[j, i].GetComponent<Cells>().Number.text = arrMinePerimeter[j, i].ToString();
                    }
                    else if (arrMinePerimeter[j, i] == 0 && arrCells[j, i].GetComponent<Cells>().type != Cells.Type.Mine)
                    {
                        arrCells[j, i].GetComponent<Cells>().type = Cells.Type.Empty;
                    }
                }
            }

            for (int i = ((ySize / 2) - 1); i <= ((ySize / 2) + 1); i++)
            {
                for (int j = ((xSize / 2) - 1); j <= ((xSize / 2) + 1); j++)
                {
                    arrCells[j, i].GetComponent<Cells>().type = Cells.Type.Empty;
                }
            }
        }
        
    }

    public void Reset()
    {
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                Destroy(arrCells[j,i]);
            }
        }
        
    }
    

    void fixedUpdate()
    {
        
    }
}
