using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    private CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GetComponent<Camera>();
        vcam = GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void unlock()
    {
        var orbital = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        orbital.m_DeadZoneWidth = 0f;
        orbital.m_DeadZoneHeight = 0f;
    }

    public void startEvent(GameObject e)
    {
        var orbital = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        orbital.m_DeadZoneWidth = 1.5f;
        orbital.m_DeadZoneHeight = 1.5f;
        e.SetActive(true);
        e.GetComponent<FightingEvent>().snapToX(transform.position.x);
    }
}
