using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image signal;
    public float distance;
    public Transform hotspot;

    // Start is called before the first frame update
    void Start()
    {
        //hotspot = GameObject.FindWithTag("Hotspot");
    }

    // Update is called once per frame
    void Update()
    {
        if (hotspot == null)
        {
            hotspot = GameObject.FindWithTag("Hotspot").transform;
        }

        distance = Vector3.Distance(hotspot.position, transform.position);

        signal.fillAmount = 1 / distance + .25f;
    }
}
