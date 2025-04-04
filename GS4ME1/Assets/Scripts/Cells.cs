using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Cells : MonoBehaviour
{
    public GameObject mainCell,NumberGO,Bomb;
    public GameObject XRCam;
    public TextMeshProUGUI Number;
    

    public enum Type
    {
        Empty,
        Mine,
        Number,
        Flagged
    }
    public Type type;
    public Vector3Int Coordinates;
    public int number;
    public bool revealed, flagged, exploded;
    private int randomNumber;
    
    
    // Start is called before the first frame update
    void Start()
    {
        XRCam = GameObject.FindWithTag("MainCamera");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        NumberGO.transform.LookAt(XRCam.transform);
        if (type != Type.Number)
        {
            NumberGO.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (type == Type.Mine)
            {
                Bomb.SetActive(true);
                NumberGO.SetActive(false);
            }

            if (type == Type.Number)
            {
                NumberGO.SetActive(true);
            }
        }
    }
}
