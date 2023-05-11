using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private Button button;

    private EventSystem eventSystem;
    
    private void OnEnable()
    {
        button.onClick.AddListener(AudioClicked);
    }

    private void Update()
    {
    }


    private void AudioClicked()
    {
        FMOD.Studio.EventInstance evento = FMODUnity.RuntimeManager.CreateInstance("event:/Button");
        evento.start();
        
    }
    
    private void OnDisable()
    {
        button.onClick.RemoveListener(AudioClicked);
    }
}
