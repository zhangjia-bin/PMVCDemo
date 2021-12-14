using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    Camera maincamera;
   public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
      
    }


    // Update is called once per frame
    void Update()
    {
        maincamera.fieldOfView = slider.value;
    }
}
