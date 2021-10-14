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
    public GameObject loading;

    // Start is called before the first frame update
    void Start()
    {
        circle.fillAmount = 0;
    }

    void Update()
    {
        if (hotspot == null)
        {
            hotspot = GameObject.FindWithTag("Hotspot").transform;
        }

        distance = Vector3.Distance(hotspot.position, transform.position);

        signal.fillAmount = 1 / distance + .25f;


        if (signal.fillAmount >= .8f)
        {
            loading.SetActive(true);
            sending.SetActive(true);

            circle.fillAmount += .5f * Time.deltaTime;
        }
        else
        {
            loading.SetActive(false);
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
