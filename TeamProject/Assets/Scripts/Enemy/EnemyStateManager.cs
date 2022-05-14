using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private Vector2[] patrollPath;
    private EnemyBaseState currentState;
    
    public EnemyPatrollingState PatrollingState;
    public EnemyAttackPlayerState AttackingState;
    public EnemyDyingState DyingState;
    
    private void Awake()
    {
        PatrollingState = new EnemyPatrollingState(patrollPath);
        AttackingState = new EnemyAttackPlayerState();
        DyingState = new EnemyDyingState();
    }
    private void Start()
    {
        SwitchState(PatrollingState);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        currentState.owner = this;
        currentState.EnterState();
    }
}
