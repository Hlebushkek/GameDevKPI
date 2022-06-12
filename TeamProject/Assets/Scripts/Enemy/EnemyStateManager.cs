using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private Vector2[] patrollPath;

    [SerializeField] private float visionDistance = 8;
    [SerializeField] private float visionAngleDegree = 30;
    [SerializeField] private int visionColliderPoints= 31;
    [SerializeField] private LayerMask visionLayers;
    private EdgeCollider2D visionCollider;

    [SerializeField] private WeaponBase weapon;

    private EnemyBaseState currentState;
    public EnemyPatrollingState PatrollingState;
    public EnemyAttackPlayerState AttackingState;
    public EnemyDyingState DyingState;
    
    private void Awake()
    {
        CreateVisionCollider();

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

        UpdateVisionCollider();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        currentState.OnTriggerEnter(other);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        currentState.owner = this;
        currentState.EnterState();
    }

    private void CreateVisionCollider()
    {
        visionCollider = gameObject.AddComponent<EdgeCollider2D>();
        visionCollider.isTrigger = true;

        UpdateVisionCollider();
    }
    private void UpdateVisionCollider()
    {
        float startAngel = transform.eulerAngles.z - visionAngleDegree / 2;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2[] points = new Vector2[visionColliderPoints];

        points[0] = Vector2.zero;
        for (int i = 1; i <visionColliderPoints-1; i++)
        {
            Vector2 rot = Utilities.DegreeToVector2(startAngel + visionAngleDegree / visionColliderPoints * i);
            RaycastHit2D raycast = Physics2D.Raycast(origin, rot, visionDistance, visionLayers);
            Debug.DrawRay(origin, rot * 4, Color.blue, 10);
            if (raycast.collider)
            {
                points[i] = Utilities.rotateByDegree(raycast.point - origin, -transform.eulerAngles.z);
            }
            else
            {
                points[i] = new Vector2(-1f + i * 2f / visionColliderPoints, 8);
            }
            
        }
        points[visionColliderPoints-1] = Vector2.zero;

        visionCollider.points = points;
    }
}
