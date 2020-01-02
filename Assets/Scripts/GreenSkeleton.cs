using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSkeleton : Skeleton
{
    public override void Update()
    {
        if (anim.GetBool("fightStarted"))
        {
            base.Update();
        }
    }

    public override void deathrattle()
    {
        GameObject.Find("MusicManager").GetComponent<MusicManager>().transitionMusic("TwilightRealm");
        base.deathrattle();
    }
}
