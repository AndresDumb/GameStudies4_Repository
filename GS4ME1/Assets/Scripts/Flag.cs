using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject flag;

    public bool inContact = false;
    public float timeElapsed;
    
    

    // Update is called once per frame
    void Update()
    {
        if (inContact && timeElapsed < 3)
        {
            timeElapsed += Time.deltaTime;
        }
        else if (inContact && timeElapsed >= 3)
        {
            
        }
        else if (!inContact)
        {
            timeElapsed = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            inContact = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            inContact = false;
        }
    }
}
