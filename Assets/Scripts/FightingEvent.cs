using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingEvent : MonoBehaviour
{
    private int numEnemies;
    private CameraController cam;
    private Transform enemies;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
        enemies = transform.Find("Enemies");
        numEnemies = enemies.childCount;
    }

    public void snapToX(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        numEnemies = enemies.childCount;
        if (numEnemies == 0)
        {
            cam.unlock();
            Destroy(gameObject);
        }
    }
}
