using UnityEngine;

public class EnemyAttackPlayerState : EnemyBaseState
{
    public override void EnterState()
    {
        AlarmEnemies();
    }

    public override void OnTriggerEnter(Collider2D other)
    {

    }

    public override void UpdateState()
    {

    }

    private void AlarmEnemies()
    {
        Debug.Log("Alarm enemies in specific range");
    }
}
