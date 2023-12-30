using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTile : Checker
{

    [SerializeField] private Transform indicator;
    public bool canColored = true;

    [SerializeField,ColorUsage(true,true)] private Color blue;
    [SerializeField, ColorUsage(true, true)] private Color red;


    protected override void OnActivated()
    {
        //indicator.GetComponent<Renderer>().material.color = red;
        indicator.GetComponent<Renderer>().material.SetColor("_EmissionColor", red);

    }

    protected override void OnDeactivated()// when reset
    {
        //indicator.GetComponent<Renderer>().material.color = blue;
        indicator.GetComponent<Renderer>().material.SetColor("_EmissionColor", blue);

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
