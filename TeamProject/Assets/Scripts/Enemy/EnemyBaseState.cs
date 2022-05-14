using UnityEngine;

public abstract class EnemyBaseState 
{
    public EnemyStateManager owner;
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void OnCollisionEnter();
}
