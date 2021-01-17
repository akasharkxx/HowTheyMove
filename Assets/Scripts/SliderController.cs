using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider sliderInTheMiddle;

    private void Update()
    {
        float controllerTriggerRT = Input.GetAxis("Right Trigger");
        sliderInTheMiddle.value = controllerTriggerRT;
    }
}
