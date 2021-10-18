using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transluscent : MonoBehaviour
{
    public GameObject hittable;
    void Update()
    {
        RaycastHit hit;
        Color storage;
        Color myNewColor;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            hittable = hit.transform.gameObject;
            if (hittable.gameObject.GetComponent<MeshRenderer>() != null) {

                myNewColor = hittable.GetComponentInChildren<MeshRenderer>().material.color;
                if (hit.transform.tag == "Block")
                {
                    storage = hittable.gameObject.GetComponentInChildren<MeshRenderer>().material.color;
                    Debug.Log(storage);
                    myNewColor.a = 0.5f;
                    hittable.gameObject.GetComponentInChildren<MeshRenderer>().material.color = myNewColor;
                    Debug.Log(hittable.gameObject.GetComponentInChildren<MeshRenderer>().material);
                }
                else { storage = myNewColor; }
                if(storage != myNewColor) {
                    myNewColor.a = 1f;
                    storage = myNewColor;
                }
            }
        }


    }
}
