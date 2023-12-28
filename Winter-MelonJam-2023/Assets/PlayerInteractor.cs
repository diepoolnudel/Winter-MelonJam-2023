using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{

    [SerializeField] private float range = 2.0f;
    [SerializeField] private Transform vc_player;

    [Header("Grabbing")]
    [SerializeField] private Transform holdpos;
    [SerializeField] private float grabForce = 150.0f;
    private GameObject heldObj;
    private Rigidbody heldObjRB;


    private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("RayCastInteractables");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        bool mouseButtonDown = Input.GetMouseButton(0);

        if (heldObj == null)
        {
            RaycastHit hit;

            if (Physics.Raycast(vc_player.position, vc_player.forward, out hit, range, layerMask))
            {
               

                if(mouseButtonDown)//Interaction
                {

                    if(hit.transform.CompareTag("grabbable"))
                    {
                        GrabObject(hit.transform.gameObject);
                    }
                }

            }

        }
        else
        {
            MoveObject();

            if (!mouseButtonDown)
            {
                DropObject();
            }


        }

        
    }



    private void GrabObject(GameObject obj)
    {
        heldObj = obj;
        heldObjRB = obj.GetComponent<Rigidbody>();

        heldObjRB.useGravity = false;
        heldObjRB.drag = 10;
        heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

        Debug.Log("Object grabed");
    }

    private void DropObject()
    {

        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj = null;
        Debug.Log("Object droped");
    }


    private void MoveObject()
    {

        if (Vector3.Distance(heldObj.transform.position, holdpos.position) > 0.01f)
        {
            Vector3 moveDirection = holdpos.position - heldObjRB.transform.position;
            heldObjRB.AddForce(moveDirection * grabForce);
        }
    }


}
