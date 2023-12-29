using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmCharm : Charm
{
    public override void Collect()
    {
        base.Collect();
        Debug.Log("Game Finished");
    }
}
