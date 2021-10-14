using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transluscent : MonoBehaviour
{
    Quaternion q;
    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        q = transform.rotation;
        rot = -transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.forward);
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.distance);
        }
    }
}
