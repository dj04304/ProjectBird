using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SoundBar_BGM : MonoBehaviour, IPointerUpHandler
{
    public AudioSource EffectTestSound;
    public Slider SoundSlider;
    public TextMeshProUGUI SoundValue;
    public GameObject SoundM;
    // Start is called before the first frame update
    void Start()
    {
        SoundBarInit();
        getSlideBarValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SoundM.GetComponent<SoundManager>().SetBGMVolume((float)(SoundSlider.value) / (float)100);
        Debug.Log((float)(SoundSlider.value) / (float)1000);

        EffectTestSound.volume = ((float)(SoundSlider.value) / (float)100)*(float)0.8;
        EffectTestSound.Play();

        getSlideBarValue();
    }

    public void playSound()
    {
        SoundManager.Instance.playButtonEffect();
    }

    private void getSlideBarValue()
    {
        SoundValue.text = ((int)SoundSlider.value).ToString();

        //Debug.Log(SoundSlider.value);
    }

    private void SoundBarInit()
    {
        SoundSlider.value = 70;
    }
}
