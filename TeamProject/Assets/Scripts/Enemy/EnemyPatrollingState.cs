using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    private Vector2 startPosition;
    private Vector2[] patrollPath;
    private int patrollPathCount = 0;
    private float speed = 2f;
    public EnemyPatrollingState(Vector2[] patrollPath)
    {
        this.patrollPath = patrollPath;
    }

    public override void EnterState()
    {
        startPosition = owner.transform.position;
    }
    public override void UpdateState()
    {
        Vector2 targetPoint = startPosition + patrollPath[patrollPathCount];
        Vector2 onwerPos = owner.transform.position;
        if (Vector2.Distance(onwerPos, targetPoint) < 0.1)
        {
            owner.transform.position = targetPoint;
            patrollPathCount++;

            if (patrollPathCount >= patrollPath.Length)
            {
                System.Array.Reverse(patrollPath);
                patrollPathCount = 0;
            }
        }
        else
        {
            owner.transform.position = Vector2.MoveTowards(onwerPos, targetPoint, Time.deltaTime * speed);
        }
    }
    public override void OnCollisionEnter()
    {

    }
}
