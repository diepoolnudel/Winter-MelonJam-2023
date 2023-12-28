using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCharm : Charm
{
    public override void Collect()
    {
        base.Collect();
        PlayerManager.HeighJump = true;
        Debug.Log("Grabcharm Collected");
    }
}
