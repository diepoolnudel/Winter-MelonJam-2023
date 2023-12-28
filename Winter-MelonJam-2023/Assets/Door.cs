using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private float offset;
    [SerializeField] private Transform door;


    public void Open()
    {
        door.position = door.position + Vector3.up * offset;
    }

    public void Close()
    {
        door.position = door.position - Vector3.up * offset;
    }
}
