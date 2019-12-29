using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{

    private Rigidbody2D myrigidbody;
    private GameObject damagenumber;
    private Animator anim;
    public GameObject DamageLoc;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        damagenumber = Resources.Load("GUI/DamageNumber") as GameObject;
        anim = GetComponent<Animator>();
    }

    public void damage(int n)
    {
        anim.Play("DummyHit", -1, 0.0f);
        var clone = Instantiate(damagenumber, DamageLoc.transform.position, Quaternion.identity) as GameObject;
        clone.GetComponent<DamageNumber>().displayNumber.text = "-" + n;
    }

    public void setHitFalse()
    {
        anim.SetBool("hit", false);
    }

    public void setHitAgainFalse()
    {
        anim.SetBool("hitDuringAnimation", false);
    }
}
