using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    void unlock()
    {
        Destroy(gameObject, 1.0f);
    }
}
