using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateManager))]
public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int maxHP = 10;
    private int currentHP;

    private EnemyStateManager stateManager;
    
    private void Awake()
    {
        stateManager = GetComponent<EnemyStateManager>();
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            stateManager.SwitchState(stateManager.DyingState);
        }
    }
}
