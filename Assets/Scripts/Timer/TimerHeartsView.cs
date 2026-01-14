using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHeartsView : MonoBehaviour
{
    [SerializeField] private RectTransform _layoutHearts;

    [SerializeField] private Image _heartPrefab;

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

        if (Images.Count > (int)_currentTime)
        {
            Destroy(Images[Images.Count - 1].gameObject);
            Images.RemoveAt(Images.Count - 1);
        }

    }

    public void Initialize(float timerSeconds)
    {
        _currentTime = timerSeconds;
        _timerSeconds = timerSeconds;

        CreateHearts();
    }

    public void SetTimerRunning(bool isRunning)
    {
        _isRunning = isRunning;
        
        if(_isRunning)
            OnTimerPlayed();
    }

    public void SetCurrentTime(float currentTime)
    { 
        _currentTime = currentTime; 
    }

    public void SetTimerPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    

    public void OnTimerPlayed()
    {
        _currentTime = _timerSeconds;

        DestroyHearts();
        CreateHearts();
    }

    private void DestroyHearts()
    {
        while (Images.Count > 0)
        {
            Destroy(Images[Images.Count - 1].gameObject);
            Images.RemoveAt(Images.Count - 1);
        }
    }

    private void CreateHearts()
    {
        for (int i = 0; i < (int)_timerSeconds; i++)
        {
            Images.Add(Instantiate(_heartPrefab, _layoutHearts));
        }
    }
}
