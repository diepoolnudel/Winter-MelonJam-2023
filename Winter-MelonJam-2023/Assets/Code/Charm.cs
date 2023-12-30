using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Charm : MonoBehaviour
{
    public UnityEvent onCollect;

    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private float amplitude = 1.0f;
    [SerializeField] private float frquency = 1.0f;

    [SerializeField] private AudioSource as_collect;

    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        float angle = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, angle);

        float offset = amplitude * Mathf.Sin(frquency*Time.time);

        Vector3 tmp = originalPos;
        tmp.y += offset;

        transform.position = tmp;
    }


    public virtual void Collect()
    {
        onCollect?.Invoke();
        as_collect.Play();
        Destroy(this.gameObject);
    }
    
}
