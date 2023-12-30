using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSound : MonoBehaviour
{

    [SerializeField] private float spaceTime = 0.1f;
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioSource as_hit;

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (timer > spaceTime)
        {
            timer = 0.0f;
            int i = Random.Range(0, hitSounds.Length);
            as_hit.PlayOneShot(hitSounds[i]);
        }
    }
}
