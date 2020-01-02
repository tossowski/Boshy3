using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");    
    }

    public virtual void Update()
    {

    }

    public virtual void OnCollect()
    {
        Destroy(transform.parent.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnCollect();
        }
    }
}
