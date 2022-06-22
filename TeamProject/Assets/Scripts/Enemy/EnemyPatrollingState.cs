using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    private Vector2 startPosition;
    private float startZRotation;

    private Vector2[] patrollPath;
    private float[] patrollZRotation;
    private int currentPathIndex = 0;
    private int currentRotationIndex = 0;

    private float speed = 2f;
    public EnemyPatrollingState(Vector2[] patrollPath, float[] patrollZRotation)
    {
        this.patrollPath = patrollPath;
        this.patrollZRotation = patrollZRotation;
    }

    public override void EnterState()
    {
        startPosition = owner.transform.position;
        startZRotation = owner.transform.rotation.eulerAngles.z;
    }
    public override void UpdateState()
    {
        if (patrollPath.Length < 1) { return; }

        Vector2 targetPoint = startPosition + patrollPath[currentPathIndex];
        float targetZRotation = startZRotation + patrollZRotation[currentRotationIndex];

        Vector2 onwerPos = owner.transform.position;
        if (Vector2.Distance(onwerPos, targetPoint) < 0.1)
        {
            owner.transform.position = targetPoint;
            currentPathIndex++;
            currentRotationIndex++;

            if (currentPathIndex >= patrollPath.Length)
            {
                System.Array.Reverse(patrollPath);
                currentPathIndex = 0;
            }
            if (currentRotationIndex >= patrollZRotation.Length)
            {
                currentRotationIndex = 0;
            }
        }
        else
        {
            owner.transform.position = Vector2.MoveTowards(onwerPos, targetPoint, Time.deltaTime * speed);
            owner.transform.rotation = Quaternion.RotateTowards(owner.transform.rotation, Quaternion.Euler(0, 0, targetZRotation), Time.deltaTime * 100);
        }
    }
    public override void OnTriggerEnter(Collider2D other) {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            EventManager.AlarmEnemyInRadius(owner.transform.position);
        }
    }
}
