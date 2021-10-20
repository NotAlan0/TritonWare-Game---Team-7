using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transluscent : MonoBehaviour
{
    public GameObject hittable;
    MeshRenderer storage;
    void Update()
    {
        RaycastHit hit;
        Color myNewColor;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            hittable = hit.transform.gameObject;
            if (hittable.gameObject.GetComponent<MeshRenderer>() != null)
            {

                myNewColor = hittable.GetComponentInChildren<MeshRenderer>().material.color;
                if (hit.transform.tag == "Block")
                {
                    storage = hittable.gameObject.GetComponentInChildren<MeshRenderer>();
                    Debug.Log(storage);
                    myNewColor.a = 0.5f;
                    storage.material.color = myNewColor;
                    Debug.Log(storage.material);
                }
                else { storage.material.color = myNewColor; }
                if (storage.material.color != myNewColor)
                {
                    myNewColor.a = 1f;
                    storage.material.color = myNewColor;
                }
            }
        }
    }
}