using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public float  xVal, yVal;
    public float xInput, yInput;
    public Slider xSlider, ySlider;

    public Vector3 Rot;

    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = xSlider.value;
        yInput = ySlider.value;
        xVal = xInput;
        yVal = yInput;
        Vector3 Rot = new Vector3(xVal, yVal, 0);
    }

    void fixedUpdate()
    {
        platform.transform.rotation= Quaternion.Euler(Rot);
    }
}
