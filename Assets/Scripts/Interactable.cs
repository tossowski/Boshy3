using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    protected GameObject player;
    protected GameObject Ekey;
    protected bool triggerStay;
    // Start is called before the first frame update
    public void Start()
    {
        Ekey = transform.Find("EKey").gameObject;
        Ekey.SetActive(false);
        player = GameObject.Find("Player");
        triggerStay = false;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerStay = true;
        }

        
        Ekey.SetActive(true);
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerStay = false;
            Ekey.SetActive(false);
        }

    }

    public virtual void Interact()
    {
        return;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown("e") && triggerStay)
        {
            Interact();
            //player.GetComponent<PlayerController>().yeetPlayerMovement();
            Ekey.SetActive(false);
        }
    }
}
