using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BackgroundGenerator : MonoBehaviour
{

    private CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        vcam = GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = vcam.transform.position * 0.9f;
        transform.position = new Vector3(pos.x, pos.y + 1, 1);

        
    }
}
