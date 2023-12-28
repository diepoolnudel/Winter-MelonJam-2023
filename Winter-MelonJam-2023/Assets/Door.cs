using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private float offset;
    [SerializeField] private Transform door;

    private bool open = false;
    public void Open()
    {
        if (open)
            return;

        door.position = door.position + Vector3.up * offset;
        open = true;
    }

    public void Close()
    {
        if(!open)
            return;

        door.position = door.position - Vector3.up * offset;

        open = false;
    }
}
