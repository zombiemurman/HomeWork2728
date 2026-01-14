using UnityEngine;

public class Enemy
{
    public Enemy(float createTime, string name)
    {
        CreateTime = createTime;
        Name = name;
    }

    public float CreateTime;

    public string Name;
}
