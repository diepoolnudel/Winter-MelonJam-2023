using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : Checker
{
    [SerializeField] private Transform plate;
    [SerializeField] private float offset;
    [SerializeField] private AudioSource as_PreasurePlate_Pressed;
    [SerializeField] private AudioSource as_PreasurePlate_Released;

    protected override void OnActivated()
    {


        plate.position = plate.position - new Vector3(0, offset, 0);
        plate.GetComponent<Renderer>().material.color = Color.green;

        as_PreasurePlate_Pressed.Play();
        as_PreasurePlate_Released.Stop();

    }

    protected override void OnDeactivated()
    {
        plate.position = plate.position + new Vector3(0, offset, 0);
        plate.GetComponent<Renderer>().material.color = Color.red;
        as_PreasurePlate_Pressed.Stop();
        as_PreasurePlate_Released.Play();
    }
   
    

}
