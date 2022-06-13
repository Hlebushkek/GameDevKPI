using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action<Vector2> OnEnemyAlalrmed;
    public static void AlarmEnemyInRadius(Vector2 triggerPosition)
    {
        if (OnEnemyAlalrmed != null) OnEnemyAlalrmed.Invoke(triggerPosition);
    }
}
