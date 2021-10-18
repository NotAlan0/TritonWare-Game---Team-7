using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image signal;
    public float distance;
    public Transform hotspot;

    public Image noise;
    public float noiseLevel;
    public Vector3 currentPos;
    public Vector3 lastPos;

    public Image circle;
    public GameObject sending;

    // Start is called before the first frame update
    void Start()
    {
        circle.fillAmount = 0;

        //This part here finds all the objects so that Boris's script can instantiate the player without errors
        signal = GameObject.FindWithTag("Signal").GetComponent<Image>();
        //hotspot = GameObject.FindWithTag("Hotspot").transform;  this one is already called in the Update()
        noise = GameObject.FindWithTag("Noise").GetComponent<Image>();
        circle = GameObject.FindWithTag("Circle").GetComponent<Image>();
        sending = GameObject.FindWithTag("Sending");
    }

    void Update()
    {
        if (hotspot == null)
        {
            hotspot = GameObject.FindWithTag("Hotspot").transform;
        }

        distance = Vector3.Distance(hotspot.position, transform.position);

        signal.fillAmount = 2 / (distance + .25f);  //This will need to be adjusted as we test out the whole map


        if (signal.fillAmount >= .85f)
        {
            sending.SetActive(true);

            circle.fillAmount += .5f * Time.deltaTime; //then we need to end it when this is full
        }
        else
        {
            sending.SetActive(false);
        }

        currentPos = transform.position;
        if (currentPos == lastPos && noiseLevel >= 0)
        {
            noiseLevel -= .5f * Time.deltaTime;
        }
        else
        if (currentPos != lastPos && noiseLevel <= 1)
        {
            noiseLevel += .5f * Time.deltaTime;
        }
        lastPos = currentPos;

        noise.fillAmount = noiseLevel;
    }
}
