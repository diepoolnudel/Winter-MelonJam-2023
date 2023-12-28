using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Charm : MonoBehaviour
{
    public virtual void Collect()
    {
        Destroy(this.gameObject);
    }
    
}
