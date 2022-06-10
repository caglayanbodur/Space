using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }

    public void SliderAmaunt(int maxAmaunt,int currentAmaunt)
    {
        int sliderAmaunt = maxAmaunt - currentAmaunt;
        slider.maxValue = maxAmaunt;
        slider.value = sliderAmaunt;
    }

   
}
