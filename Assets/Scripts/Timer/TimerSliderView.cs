using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private bool _isRunning;
    
    private bool _isPaused;

    private float _currentTime;

    private float _timerSeconds;

    private List<Image> Images = new List<Image>();

    private void Update()
    {
        if (_isRunning == false)
            return;

        if(_isPaused)
            return;

        _slider.value = _currentTime / _timerSeconds;
    }

    public void SetTimerRunning(bool isRunning)
    {
        _isRunning = isRunning;
    }

    public void SetCurrentTime(float currentTime)
    { 
        _currentTime = currentTime; 
    }

    public void SetTimerPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    public void Initialize(float timerSeconds)
    {
        _timerSeconds = timerSeconds;
    }

    public void OnTimerPlayed()
    {
        _currentTime = _timerSeconds;
    }
}
