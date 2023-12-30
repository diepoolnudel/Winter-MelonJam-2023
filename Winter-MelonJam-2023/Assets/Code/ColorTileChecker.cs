using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorTileChecker : MonoBehaviour
{

    [SerializeField] private ColorTile[] checkers;
    private bool[] checkerTrue;
    public UnityEvent onActivated;
    private bool allActivated = false;
    private float currentActivated = 0;

    [SerializeField] private AudioSource as_ColorTileActivated;
    [SerializeField] private AudioSource as_ColorTileFailed;

    void Start()
    {

        checkerTrue = new bool[checkers.Length];

        for (int i = 0; i < checkers.Length; i++)
        {
            var ii = i;
            checkers[i].onActivated += () =>
            {
                if (checkerTrue[ii])
                {
                    DisableColorTiles();
                    return;
                }
                else
                {
                    as_ColorTileActivated.Play();
                    checkerTrue[ii] = true;
                    currentActivated++;
                }



                if (currentActivated == checkers.Length)
                    AllActivated();
            };


        }

    }


    private void DisableColorTiles()
    {
        if (allActivated)
            return;

        as_ColorTileFailed.Play();
        foreach (var checker in checkers)
        {
            checker.canColored = false;
        }
    }

    public void ResetColorTiles()
    {

        if (allActivated)
            return;
        currentActivated = 0;
        foreach (var checker in checkers)
        {
            checker.ResetChecker();
        }
        for (int i = 0; i < checkers.Length; i++)
        {
            checkerTrue[i] = false;
        }

    }


    public void AllActivated()
    {
        onActivated.Invoke();
        Debug.Log("All ColorTile Activated");
        allActivated = true;
    }

}
