using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private float offset;
    [SerializeField] private Transform door;
    [SerializeField] private bool openOnStart = false;

    [Header("Sound")]
    [SerializeField] private AudioSource as_doorOpen;
    [SerializeField] private AudioSource as_doorClose;


    private void Start()
    {
        if (openOnStart)
            Open();
    }


    private bool open = false;
    public void Open()
    {
        if (open)
            return;

        as_doorClose.Stop();
        as_doorOpen.Play();
        door.position = door.position + Vector3.up * offset;
        open = true;
    }

    public void Close()
    {
        if(!open)
            return;


        as_doorClose.Play();
        as_doorOpen.Stop();
        door.position = door.position - Vector3.up * offset;

        open = false;
    }
}
