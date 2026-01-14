using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Button _battonPlay;
    [SerializeField] private Button _battonPaused;
    [SerializeField] private Button _battonStop;

    private TimerController _timerController;

    private void Awake()
    {
        _battonPlay.onClick.AddListener(OnTimerPlayed);
        _battonPaused.onClick.AddListener(OnTimerPaused);
        _battonStop.onClick.AddListener(OnTimerStop);
    }

    private void OnDestroy()
    {
        _battonPlay.onClick.RemoveListener(OnTimerPlayed);
        _battonPaused.onClick.RemoveListener(OnTimerPaused);
        _battonStop.onClick.RemoveListener(OnTimerStop);
    }

    public void Initialize(TimerController timerController)
    {
        _timerController = timerController;
    }

    private void OnTimerStop()
    {
        _timerController.OnTimerStop();
    }

    private void OnTimerPaused()
    {
        _timerController.OnTimerPaused();
    }

    private void OnTimerPlayed()
    {
        _timerController.OnTimerPlayed();
    }
}
