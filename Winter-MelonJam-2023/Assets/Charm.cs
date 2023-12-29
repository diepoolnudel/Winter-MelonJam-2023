using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Charm : MonoBehaviour
{
    public UnityEvent onCollect;

    public virtual void Collect()
    {
        onCollect?.Invoke();
        Destroy(this.gameObject);
    }
    
}
