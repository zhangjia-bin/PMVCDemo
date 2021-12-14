using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class App : MonoBehaviour
{
    public GameObject obj;
    public Button luack;
    public Button bag;
    private void Awake()
    {
        luack.onClick.AddListener(OpenLuack);
        bag.onClick.AddListener(OpenBag);
       // obj.isStatic = true;

    }

    private  void OpenBag()
    {
        MyFacade.GetInstance().LaunchBag();
       
    } 
    private  void OpenLuack()
    {
        MyFacade.GetInstance().Launch();
    }
}
