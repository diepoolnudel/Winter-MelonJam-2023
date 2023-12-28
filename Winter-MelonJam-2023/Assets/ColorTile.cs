using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTile : Checker
{

    [SerializeField] private Transform indicator;
    public bool canColored = true;


    protected override void OnActivated()
    {
        indicator.GetComponent<Renderer>().material.color = Color.red;
    }

    protected override void OnDeactivated()// when reset
    {
        indicator.GetComponent<Renderer>().material.color = Color.blue;
        canColored = true;
    }

    protected override void TriggerEnterd(Collider other)
    {
        if (!canColored)
            return;


        base.TriggerEnterd(other);
        activ = false;
    }
}
