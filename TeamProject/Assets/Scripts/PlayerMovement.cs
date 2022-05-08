using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float verticalSpeed = 10f;
    [SerializeField] float horizonatalSpeed = 10f;
    float verticalMove, horizontalMove;
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        horizontalMove = Input.GetAxis("Horizontal") * horizonatalSpeed * Time.deltaTime;
        transform.Translate(0, verticalMove, 0);
        transform.Translate(horizontalMove, 0, 0);
    }
}
