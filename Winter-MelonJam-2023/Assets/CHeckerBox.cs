using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CHeckerBox : Checker
{

    public UnityEvent onEntered;
    public UnityEvent onExited;


    protected override void OnActivated()
    {
        onEntered?.Invoke();
    }

    protected override void OnDeactivated()
    {
        onExited?.Invoke();
    }


}
