using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool canMove = true;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] private float horizonatalSpeed = 10f;
    private float verticalMove, horizontalMove;
    private void Update()
    {
        if (canMove) {
            verticalMove = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
            horizontalMove = Input.GetAxis("Horizontal") * horizonatalSpeed * Time.deltaTime;
            transform.Translate(0, verticalMove, 0);
            transform.Translate(horizontalMove, 0, 0);
        }
    }

    public void setMoving(bool canMove)
    {
        this.canMove = canMove;
    }
}
