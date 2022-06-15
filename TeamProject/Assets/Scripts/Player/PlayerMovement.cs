using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float movementSpeed;
    [SerializeField] private float MOVEMENT_BASE_SPEED = 8f;
    private bool canMove = true;
    private bool isMoving = false;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        ProcessInputs();

        if (canMove)
        {
            Move();
        }
    }

    private void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        if (movementDirection.x != 0 || movementDirection.y != 0) { isMoving = true; }
        else { isMoving = false;}

    }
    private void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    public void SetMoving(bool canMove)
    {
        this.canMove = canMove;
    }
    public bool CanMove()
    {
        return canMove;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
