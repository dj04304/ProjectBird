using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GetSlideBarValue : MonoBehaviour, IPointerUpHandler
{
    public AudioSource EffectTestSound;
    public Slider SoundSlider;
    public TextMeshProUGUI SoundValue;
    // Start is called before the first frame update
    void Start()
    {
        SoundBarInit();
    }

    // Update is called once per frame
    void Update()
    {
        getSlideBarValue();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EffectTestSound.volume = (float)(SoundSlider.value) / (float)100;
        //Debug.Log(EffectTestSoond.volume);
        EffectTestSound.Play();
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
