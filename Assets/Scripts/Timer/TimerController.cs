using System;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    Timer _timer;

    [SerializeField] private TimerSliderView _timerSliderView;
    [SerializeField] private TimerHeartsView _timerHeartsView;
    [SerializeField] private ButtonView _buttonView;

    [SerializeField] private float _timerTime;

    private void Start()
    {
        _timer = new Timer(this, _timerTime);

        _buttonView.Initialize(this);
        _timerSliderView.Initialize(_timerTime);
        _timerHeartsView.Initialize(_timerTime);

        _timer.CurrentTime.Changed += OnChangedCurrentTime;
        _timer.IsPaused.Changed += OnChangedPaused;

        _timer.TimerIsRunning += OnTimerIsRunning;
    }

    private void OnChangedPaused(bool arg1, bool isPaused)
    {
        _timerSliderView.SetTimerPaused(isPaused);
        _timerHeartsView.SetTimerPaused(isPaused);
    }

    private void OnChangedCurrentTime(float arg1, float currentTime)
    {
        _timerSliderView.SetCurrentTime(currentTime);
        _timerHeartsView.SetCurrentTime(currentTime);
    }

    private void OnTimerIsRunning(bool isRunning)
    {
        _timerSliderView.SetTimerRunning(isRunning);
        _timerHeartsView.SetTimerRunning(isRunning);
    }

    private void OnDestroy()
    {

        _timer.CurrentTime.Changed -= OnChangedCurrentTime;
        _timer.IsPaused.Changed -= OnChangedPaused;

        _timer.TimerIsRunning -= OnTimerIsRunning;

    }

    public void OnTimerPlayed() => _timer.Start();
    public void OnTimerPaused() => _timer.Paused();
    public void OnTimerStop() => _timer.Stop();
}
