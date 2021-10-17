using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transluscent : MonoBehaviour
{
    public GameObject hittable;
    void Update()
    {
        RaycastHit hit;
       

        //i changed the position and rotation to the camera's 
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            hittable = hit.transform.gameObject;
            Color thisColor = hittable.gameObject.GetComponent<Renderer>().material.color;
            Debug.DrawLine(transform.position, transform.forward * 100f, Color.yellow);

            if (hit.transform.tag == "Block")
            {
                //make translucent

                thisColor.a = 0f;
                thisColor = Color.red;
                Debug.Log(hittable.gameObject.GetComponent<Renderer>().material);

            }
            else
            {
                //make opaque
                thisColor.a = 125;
            }
        }
    }
}
