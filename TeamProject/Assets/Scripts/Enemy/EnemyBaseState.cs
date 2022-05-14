using UnityEngine;

public abstract class EnemyBaseState 
{
    public EnemyStateManager owner;
    abstract public void EnterState();
    abstract public void UpdateState();
    abstract public void OnCollisionEnter();
}
