using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;

    private Vector2 movementDirection;
    private float movementSpeed;
    [SerializeField] private float MOVEMENT_BASE_SPEED = 8f;
    private bool canMove = true;
    private bool isMoving = false;

    private Vector2 mousePosition;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        ProcessInputs();

        TryMove();

        TryRotate();
    }

    private void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        if (movementDirection.x != 0 || movementDirection.y != 0) { isMoving = true; }
        else { isMoving = false; }

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void TryMove()
    {
        if (canMove)
        {
            rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
        } else { rb.velocity = Vector2.zero; }
        
    }

    private void TryRotate()
    {
        Vector2 lookDir = mousePosition - rb.position;
        float angle =  Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
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
