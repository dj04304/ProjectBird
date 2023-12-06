using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SoudBar_Effect : MonoBehaviour, IPointerUpHandler
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
        SoundM.GetComponent<SoundManager>().EffectVolume = (float)(SoundSlider.value) / (float)100;
        EffectTestSound.volume = ((float)(SoundSlider.value) / (float)100)*(float)0.8;
        EffectTestSound.Play();
        getSlideBarValue();
        //SoundManager.Instance.playGameOver();
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
