using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected string name;
    private GameObject player;

    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.Find("Player");
    }

    public virtual void OnCollect()
    {
        player.GetComponent<Inventory>().addItem(this);
        
        Destroy(gameObject);
    }

    public string getName()
    {
        return name;
    }

    public override string ToString() {
        return name;
    }
}
