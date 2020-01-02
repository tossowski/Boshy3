using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectible : Collectible
{

    public override void OnCollect()
    {
        HealthManager manager = player.GetComponent<HealthManager>();
        if (manager.currHealth == manager.maxHearts)
        {
            return;
        }
        Sound.SoundFX.playSound("SoundFX/HeartCollect", false, GlobalSettings.Settings.soundfxVolume);
        player.GetComponent<HealthManager>().restoreHealth(2);
        base.OnCollect();
    }
}
