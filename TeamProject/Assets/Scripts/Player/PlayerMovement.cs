using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool canMove = true;
    private bool isMoving = false;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] private float horizonatalSpeed = 10f;
    private float verticalMove, horizontalMove;
    private void Update()
    {
        if (canMove) {
            verticalMove = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
            horizontalMove = Input.GetAxis("Horizontal") * horizonatalSpeed * Time.deltaTime;
            
            if (verticalMove != 0 || horizontalMove != 0) { isMoving = true;}
            else {isMoving = false;}

            transform.Translate(0, verticalMove, 0);
            transform.Translate(horizontalMove, 0, 0);
        }
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
