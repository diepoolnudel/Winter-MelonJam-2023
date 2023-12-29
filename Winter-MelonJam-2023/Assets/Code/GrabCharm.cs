using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCharm : Charm
{
    public override void Collect()
    {
        base.Collect();
        PlayerManager.CanCrab = true;
        Debug.Log("Grabcharm Collected");
    }
}
