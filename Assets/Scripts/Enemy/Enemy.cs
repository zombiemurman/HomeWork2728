using UnityEngine;

public class Enemy
{
    Timer _timer;

    public Enemy(string name, TypeDie typeDie, MonoBehaviour coroutineRunner = null, float StartSeconds = 0)
    {
        Name = name;
        TypeDie = typeDie;

        if(TypeDie == TypeDie.Time)
        {
            _timer = new Timer(coroutineRunner, StartSeconds);
            _timer.Start();
        } 
    }

    public float CurrentTime => _timer.CurrentTime;

    public string Name { get; private set; }

    public TypeDie TypeDie { get; private set; }
}
