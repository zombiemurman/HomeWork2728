using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private ReactiveVariable<float> _currentTime;

    private ReactiveVariable<bool> _isPaused;

    public event Action<bool> TimerIsRunning;
 
    private float _startSeconds;

    private float _waitingSeconds;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _coroutine;

    public Timer(MonoBehaviour coroutineRunner, float startSeconds)
    {
        _startSeconds = startSeconds;

        _currentTime = new ReactiveVariable<float>(startSeconds);

        _isPaused = new ReactiveVariable<bool>(false);

        _coroutineRunner = coroutineRunner;

        _waitingSeconds = 0.1f;
    }

    public IReadOnlyVariable<float> CurrentTime => _currentTime;

    public IReadOnlyVariable<bool> IsPaused => _isPaused;

    public bool IsRunning { get; private set; }

    public void Start()
    {
        if (_coroutine != null)
            _coroutineRunner.StopCoroutine(_coroutine);

        _coroutine = _coroutineRunner.StartCoroutine(StartProcess());

        TimerIsRunning?.Invoke(true);
        
        _isPaused.Value = false;
    }

    public void Paused()
    {
        _isPaused.Value = !_isPaused.Value;
    }

    public void Stop()
    {
        _isPaused.Value = false;
        
        if (_coroutine != null)
            _coroutineRunner.StopCoroutine(_coroutine);

        TimerIsRunning?.Invoke(false);
    }

    IEnumerator StartProcess()
    {
        IsRunning = true;

        _currentTime.Value = _startSeconds;

        while (_currentTime.Value > 0)
        {
            while(_isPaused.Value)
                yield return null;

            yield return new WaitForSeconds(_waitingSeconds);
            
            _currentTime.Value -= _waitingSeconds;

        }

        IsRunning = false;

        yield return null;
    }

}
