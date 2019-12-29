using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingEvent : MonoBehaviour
{
    private int numEnemies;
    private CameraController cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
        numEnemies = gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        numEnemies = gameObject.transform.childCount;
        if (numEnemies == 0)
        {
            cam.unlock();
            Destroy(gameObject);
        }
    }
}
