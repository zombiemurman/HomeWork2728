using UnityEngine;

public class TimerService : MonoBehaviour
{
    Timer _timer;

    [SerializeField] private TimerView _timerView;

    [SerializeField] private float _timerTime;

    private void Start()
    {
        _timer = new Timer(this, _timerTime);

        _timerView.Initialize(_timerTime);

        _timerView.CurrentTimed += OnCurrentTime;
        _timerView.TimerPlayed += OnTimerPlayed;
        _timerView.TimerPaused += OnTimerPaused;
        _timerView.IsTimerRanning += OnTimerRunning;
        _timerView.TimerStoped += OnTimerStop;
    }

    private void OnDestroy()
    {
        _timerView.CurrentTimed -= OnCurrentTime;
        _timerView.TimerPlayed -= OnTimerPlayed;
        _timerView.TimerPaused -= OnTimerPaused;
        _timerView.IsTimerRanning -= OnTimerRunning;
        _timerView.TimerStoped -= OnTimerStop;
    }

    private bool OnTimerRunning() => _timer.IsRunning;
    private float OnCurrentTime() => _timer.CurrentTime;
    private void OnTimerPlayed() => _timer.Start();
    private void OnTimerPaused() => _timer.Paused();
    private void OnTimerStop() => _timer.Stop();
}
