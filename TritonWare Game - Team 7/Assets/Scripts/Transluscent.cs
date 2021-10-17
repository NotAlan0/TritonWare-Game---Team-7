using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transluscent : MonoBehaviour
{
    public GameObject hittable;
    void Update()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            hittable = hit.transform.gameObject;
            if (hittable.gameObject.GetComponent<MeshRenderer>() != null) {

                Color myNewColor = hittable.GetComponentInChildren<MeshRenderer>().material.color;
                Debug.DrawLine(transform.position, transform.forward * 100f, Color.yellow);

                if (hit.transform.tag == "Block")
                {
                    //make translucen
                    myNewColor.a = 0.5f;
                    hittable.gameObject.GetComponentInChildren<MeshRenderer>().material.color = myNewColor;
                    Debug.Log(hittable.gameObject.GetComponentInChildren<MeshRenderer>().material);

                }
                else
                {
                    myNewColor.a = 1f;
                    hittable.gameObject.GetComponentInChildren<MeshRenderer>().material.color = myNewColor;
                }
            }
        }
    }
    
}
