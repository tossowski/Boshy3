using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : Item
{

    public override void Start()
    {
        base.Start();
        name = "BossKey";
    }
    // TODO add player inventory and change this!!!
    public override void OnCollect()
    {
        base.OnCollect();
    }
}
