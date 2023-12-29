using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{




    public static bool CanCrab = false;
    public static bool HeighJump = false;

    private static bool canMove = false;
    public static bool CanMove
    {
        set {
            if(value)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Debug.Log("Play can move");
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Debug.Log("Play can not move");
            }
            canMove = value; 
        }

        get => canMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        if(Input.GetKeyDown(KeyCode.F1))
        {
            CanMove = !CanMove;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            CanCrab = true;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            HeighJump = true;
        }

        if(Input.GetKeyDown(KeyCode.F12))
        {
            CanMove = false;
            CanCrab = false;
            HeighJump = false;
        }

#endif

    }
}
