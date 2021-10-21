using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    // Update is called once per frame
    RaycastHit hit;
    Color thisColor;

    Vector3 changedPosition;
    Vector3 direction;

    //MeshRenderer renderer;
    private void Start()
    {
        //renderer = GetComponent<MeshRenderer>();
        Vector3 direction = new Vector3(0f, 0f, transform.forward.z);
        //Vector3 changedPosition = new Vector3(transform.position.x + renderer.bounds.size.x, transform.position.y, transform.position.z); //this creates a position vector
                                                                                                                    //adjusted to the side of the sprite
    }
    void Update()
    {
        //for(int i = 0; i > )
        if (Physics.Raycast(changedPosition, direction, out hit)) { //gotta change the direction of this to the camera's direction
            Debug.DrawLine(transform.position, transform.forward, Color.yellow);
            if (hit.transform.gameObject.GetComponent<MeshRenderer>() != null)
            {
                thisColor = transform.GetComponent<MeshRenderer>().material.color;
                thisColor.a = 1f;
                transform.GetComponent<MeshRenderer>().material.color = thisColor;
            }
            else {
                thisColor = transform.GetComponent<MeshRenderer>().material.color;
                thisColor.a = .5f;
                transform.GetComponent<MeshRenderer>().material.color = thisColor;
            }
        }
    }
}
