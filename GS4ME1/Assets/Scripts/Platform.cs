using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public GameObject Cell;
    public GameObject Cell2;
    public int xSize, ySize;
    public float Scale;
    public int randomNum;
    public GameObject[,] arrCells;
    public bool[,] arrMines;
    public int[,] arrMinePerimeter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        randomNum = Random.Range(15, 30);
        xSize = randomNum;
        ySize = randomNum;
        arrCells = new GameObject[xSize, ySize];
        arrMines = new bool[xSize,ySize];
        arrMinePerimeter = new int[xSize,ySize];
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                arrCells[j, i] = Instantiate(Cell, new Vector3(j*Scale, 0, i*Scale), Quaternion.identity);
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
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void fixedUpdate()
    {
        
    }
}
