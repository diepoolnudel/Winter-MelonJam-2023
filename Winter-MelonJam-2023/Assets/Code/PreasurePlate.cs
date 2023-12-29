using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : Checker
{
    [SerializeField] private Transform plate;
    [SerializeField] private float offset;

    protected override void OnActivated()
    {
        plate.position = plate.position - new Vector3(0, offset, 0);
        plate.GetComponent<Renderer>().material.color = Color.green;
    }

    protected override void OnDeactivated()
    {
        plate.position = plate.position + new Vector3(0, offset, 0);
        plate.GetComponent<Renderer>().material.color = Color.red;
    }
   
    

}
