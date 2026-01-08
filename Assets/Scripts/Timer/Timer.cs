using System.Collections;
using UnityEngine;

public class Timer
{
    private float _startSeconds;

    private float _waitingSeconds;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _coroutine;

    public Timer(MonoBehaviour coroutineRunner, float startSeconds)
    {
        _startSeconds = startSeconds;
        _coroutineRunner = coroutineRunner;

        _waitingSeconds = 0.1f;
    }

    public float CurrentTime { get; private set; }

    public bool IsRunning { get; private set; }

    public bool IsPaused { get; private set; }

    public void Start()
    {
        if (_coroutine != null)
            _coroutineRunner.StopCoroutine(_coroutine);

        _coroutine = _coroutineRunner.StartCoroutine(StartProcess());
        
        IsPaused = false;
    }

    public void Paused()
    {
        IsPaused = !IsPaused;
    }

    public void Stop()
    {
        IsPaused = false;
        
        if (_coroutine != null)
            _coroutineRunner.StopCoroutine(_coroutine);
    }

    IEnumerator StartProcess()
    {
        IsRunning = true;

        CurrentTime = _startSeconds;

        while (CurrentTime > 0)
        {
            while(IsPaused)
                yield return null;

            yield return new WaitForSeconds(_waitingSeconds);
            CurrentTime -= _waitingSeconds;
        }

        IsRunning = false;

        yield return null;
    }

}
