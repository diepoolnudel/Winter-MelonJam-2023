using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Checker : MonoBehaviour
{

    [SerializeField] private float[] canActivatedBy;


    public delegate void activated();
    public event activated onActivated;
    public delegate void deactivated();
    public event deactivated onDeactivated;

    protected abstract void OnActivated();
    protected abstract void OnDeactivated();


    private void Start()
    {
        onActivated += OnActivated;
        onDeactivated += OnDeactivated;
    }

    private int activateFromCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnterd(other);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExit(other);
        
    }

    private void TriggerEnterd(Collider other)
    {
        CanActivate canActivate = other.GetComponent<CanActivate>();

        if(canActivate != null && canActivatedBy.Contains(canActivate.Type))
        {
            activateFromCount++;
            onActivated?.Invoke();


        }
    }

    private void TriggerExit(Collider other)
    {
        CanActivate canActivate = other.GetComponent<CanActivate>();

        if (canActivate != null && canActivatedBy.Contains(canActivate.Type))
        {
            activateFromCount--;
            if (activateFromCount <= 0)
            {
                onDeactivated?.Invoke();
                activateFromCount = 0;
            }

        }

    }




}


