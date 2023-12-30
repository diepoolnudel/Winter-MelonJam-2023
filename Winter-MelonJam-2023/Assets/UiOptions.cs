using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UiOptions : MonoBehaviour
{

    [SerializeField] private Slider slider_mouseSens;
    [SerializeField] private Slider slider_gamma;
    [SerializeField] private Toggle toggle_music;
    [SerializeField] private AudioSource as_music;
    [SerializeField] private VolumeProfile globalVolume;

    // Start is called before the first frame update
    void Start()
    {
        slider_mouseSens.value = (int)(PlayerMovement.lookSpeed * 10);
        as_music = GameObject.Find("as_musik").GetComponent<AudioSource>();

        UnityEngine.Rendering.Universal.LiftGammaGain gamma;
        globalVolume.TryGet(out gamma);
        slider_gamma.value = gamma.gamma.value.x - 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMouseSens()
    {
        PlayerMovement.lookSpeed = slider_mouseSens.value;
    }

    public void SetMusic()
    {

        if (toggle_music.isOn)
            as_music.Play();
        else
            as_music.Stop();

    }


    public void SetVolumeProfile()
    {
        UnityEngine.Rendering.Universal.LiftGammaGain gamma;
        globalVolume.TryGet(out gamma);
        gamma.gamma.Override( Vector4.zero + new Vector4( slider_gamma.value, slider_gamma.value, slider_gamma.value, slider_gamma.value));
    }

}
