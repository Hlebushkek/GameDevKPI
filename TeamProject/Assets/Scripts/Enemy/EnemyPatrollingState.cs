using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    private Vector2 startPosition;
    private Vector2[] patrollPath;
    private int currentPathIndex = 0;
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
        if (patrollPath.Length < 1) { return; }

        Vector2 targetPoint = startPosition + patrollPath[currentPathIndex];
        Vector2 onwerPos = owner.transform.position;
        if (Vector2.Distance(onwerPos, targetPoint) < 0.1)
        {
            owner.transform.position = targetPoint;
            currentPathIndex++;

            if (currentPathIndex >= patrollPath.Length)
            {
                System.Array.Reverse(patrollPath);
                currentPathIndex = 0;
            }
            Debug.Log(currentPathIndex);
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
