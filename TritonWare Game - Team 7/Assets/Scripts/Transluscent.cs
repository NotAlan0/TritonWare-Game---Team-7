using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transluscent : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;

        //i changed the position and rotation to the camera's 
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            //Debug.Log(hit.distance);
            Debug.DrawLine(transform.position, transform.forward * 100f, Color.yellow);

            if (hit.transform.tag == "Block")
            {
                //make translucent

            }
            else
            {
                //make opaque
            }
        }
    }
}
