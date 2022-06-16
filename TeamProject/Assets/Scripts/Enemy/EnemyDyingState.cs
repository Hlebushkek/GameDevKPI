using UnityEngine;

public class EnemyDyingState : EnemyBaseState
{
    public override void EnterState()
    {
        owner.canSwitchState = false;

        GameObject.Destroy(owner.gameObject);
    }

    public override void OnTriggerEnter(Collider2D other)
    {

    }

    public override void UpdateState()
    {

    }
}
