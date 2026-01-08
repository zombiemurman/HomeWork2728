using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    public event Func<float> CurrentTimed;

    public event Func<bool> IsTimerRanning;

    public event Action TimerPlayed;

    public event Action TimerPaused;
    
    public event Action TimerStoped;

    [SerializeField] private Slider _slider;

    [SerializeField] private RectTransform _layoutHearts;

    [SerializeField] private Image _heartPrefab;

    private float _currentTime;

    private float _timerSeconds;

    private List<Image> Images = new List<Image>();

    private void Update()
    {
        if(IsTimerRanning != null)
        {
            if (IsTimerRanning.Invoke() == false)
                return;
        }

        if (CurrentTimed != null)
        {
            _currentTime = CurrentTimed.Invoke();
            _slider.value = _currentTime / _timerSeconds;

            if (Images.Count > (int)_currentTime)
            {
                Destroy(Images[Images.Count - 1].gameObject);
                Images.RemoveAt(Images.Count - 1);
            }  
        }       
    }

    public void Initialize(float timerSeconds)
    {
        _timerSeconds = timerSeconds;

        CreateHearts();
    }

    public void OnTimerPlayed()
    {
        TimerPlayed?.Invoke();

        DestroyHearts();
        CreateHearts();
    }

    public void OnTimerPaused() => TimerPaused?.Invoke();
    public void OnTimerStop() => TimerStoped?.Invoke();
    
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
