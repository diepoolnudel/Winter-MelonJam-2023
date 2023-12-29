using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CheckerGroup : MonoBehaviour
{


    [SerializeField] private Checker[] checkers;
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;

    private float currentActivated = 0;
    private bool allActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < checkers.Length; i++ )
        {
            var ii = i;
            checkers[i].onActivated += () => 
            { 
                currentActivated++;

                if (currentActivated == checkers.Length)
                    AllActivated();
            };


            checkers[i].onDeactivated += () =>
            {
                currentActivated--;

                if (allActivated)
                    Deactivate();
            };

        }
        
    }


    public void AllActivated()
    {
        onActivated.Invoke();
        Debug.Log("All Activated");
        allActivated = true;
    }

    public void Deactivate()
    {
        onDeactivated.Invoke();
        allActivated = false;
        Debug.Log("Deactivate");
    }


}
