using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    //RaycastHit hit;

    public GameObject wall;

    //Vector3 changedPosition;
    //Vector3 direction;

    //MeshRenderer renderer;

    private void Start()
    {
        //renderer = GetComponent<MeshRenderer>();
        //Vector3 direction = new Vector3(0f, 0f, transform.forward.z);
        //Vector3 changedPosition = new Vector3(transform.position.x + renderer.bounds.size.x, transform.position.y, transform.position.z); //this creates a position vector
                                                                                                                    //adjusted to the side of the sprite
    }
    void Update()
    {
        /*for(int i = 0; i > )
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
        }*/
    }

    void OnTriggerEnter(Collider collider)
    {
        var bruh = wall.GetComponent<MeshRenderer>().material.color;
        
        if (collider.tag == "PCollider")
        {
            wall.GetComponent<MeshRenderer>().material.color = new Color(bruh.r,bruh.g, bruh.b, 0.5f);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        var bruh = wall.GetComponent<MeshRenderer>().material.color;

        wall.GetComponent<MeshRenderer>().material.color = new Color(bruh.r,bruh.g, bruh.b, 1f);
    }
}
