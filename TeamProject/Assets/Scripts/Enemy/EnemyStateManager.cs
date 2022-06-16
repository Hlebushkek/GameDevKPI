using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyStats))]
public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private Vector2[] patrollPath;

    [SerializeField] private float triggerDistance = 16;

    [Header("Vision Field")]
    [SerializeField] private float visionDistance = 8;
    [SerializeField] private float visionAngleDegree = 30;
    [SerializeField] private int visionColliderPoints= 30;
    [SerializeField] private LayerMask visionLayers;
    [SerializeField] private bool shouldDrawVisionRays = false;
    private EdgeCollider2D visionCollider;

    [SerializeField] private WeaponBase weapon;

    public bool canSwitchState = true;
    private EnemyBaseState currentState;
    public EnemyPatrollingState PatrollingState;
    public EnemyAttackPlayerState AttackingState;
    public EnemyDyingState DyingState;
    
    private void Awake()
    {
        CreateVisionCollider();

        EventManager.OnEnemyAlalrmed += TryGetAlarmed;

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
        if (!canSwitchState) { return; }
        
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
        float del1taAngel = (float)visionAngleDegree / (visionColliderPoints - 2);
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);

        Vector2[] points = new Vector2[visionColliderPoints];

        points[0] = Vector2.zero;
        for (int i = 1; i < visionColliderPoints - 1; i++)
        {
            Vector2 rot = Utilities.DegreeToVector2(startAngel + del1taAngel * (i-1));
            RaycastHit2D raycast = Physics2D.Raycast(origin, rot, visionDistance, visionLayers);
            
            if (raycast.collider)
            {
                if (shouldDrawVisionRays) Debug.DrawRay(origin, rot * visionDistance, Color.red);
                points[i] = Utilities.rotateByDegree(raycast.point - origin, -transform.eulerAngles.z);
            }
            else
            {
                if (shouldDrawVisionRays) Debug.DrawRay(origin, Utilities.DegreeToVector2(transform.eulerAngles.z + -visionAngleDegree / 2 + del1taAngel * (i-1)) * visionDistance, Color.blue);
                points[i] = Utilities.rotateByDegree(new Vector2(0, visionDistance), -visionAngleDegree / 2 + del1taAngel * (i-1) - 90);
            }
            
        }
        points[visionColliderPoints-1] = Vector2.zero;

        visionCollider.points = points;
    }

    private void TryGetAlarmed(Vector2 triggerPosition)
    {
        if (Vector2.Distance(triggerPosition, transform.position) < triggerDistance)
        {
            SwitchState(AttackingState);
            Debug.LogWarning(gameObject.name + " was alarmed");
        }
    }
}
