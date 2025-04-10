using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class Platform : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public GameObject EmptyParent;
    private GameObject emptyParent;
    public GameObject Cell;
    public GameObject Cell2;
    public int xSize, ySize;
    public float Scale, moveSpeed;
    public int randomNum;
    public GameObject[,] arrCells;
    public bool[,] arrMines;
    public int[,] arrMinePerimeter;
    public Slider slider;
    public Vector3 Coordinates;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public FixedJoystick fixedJoystick;
    public GameObject XRCam;
    public GameObject Player, NewGame;
    public bool placed  = false;
    public bool NewGameActive = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Scale = 0.3f;
        emptyParent = Instantiate(EmptyParent, new Vector3(XRCam.transform.position.x,XRCam.transform.position.y -10f, XRCam.transform.position.z), Quaternion.identity);
        

    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;

        if (placed) return;
        

        if (raycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.Planes))
        {
            foreach (var hitPose in hits)
            {
                
                EmptyParent.transform.position = new Vector3(hitPose.pose.position.x, hitPose.pose.position.y - 10f, hitPose.pose.position.z);
                            placed = true;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (placed  && NewGameActive == false)
        {
            NewGame.SetActive(true);
            NewGameActive = true;
        }
            
        
        
        Movement();
        
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                arrCells[j,i].transform.localScale = new Vector3(Scale, Scale, Scale);
                arrCells[j, i].transform.localPosition = new Vector3((emptyParent.transform.position.x + (j*1.5f)) *Scale, arrCells[j,i].transform.position.y,(emptyParent.transform.position.z + (i*1.5f))*Scale);
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
                    arrCells[j, i] = Instantiate(Cell, new Vector3((emptyParent.transform.position.x + (j*1.5f)) * Scale, (emptyParent.transform.position.y),(emptyParent.transform.position.z + (i*1.5f)) * Scale), Quaternion.identity);
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

    void Movement()
    {
        
        float xInput = fixedJoystick.Horizontal;
        float yInput = fixedJoystick.Vertical;
        Vector3 ARForward = XRCam.transform.forward * yInput;
        Vector3 ARRight = XRCam.transform.right * xInput;
        ARForward *= moveSpeed;
        ARRight *= moveSpeed;
        emptyParent.transform.position += ARForward;
        emptyParent.transform.position += ARRight;
        
    }

    public void ChangeSize(Slider slider)
    {
        Scale = slider.value;
    }
    

    void fixedUpdate()
    {
        
    }
}
