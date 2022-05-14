using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private bool followPlayer = true;
    private Transform player;
    private PlayerMovement playerMovement;
    private Camera cam;
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;

        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            followPlayer = false;
            playerMovement.setMoving(false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            followPlayer = true;
            playerMovement.setMoving(true);
        }

        if (followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            LookOnMouse();
        }
    }

    private void FollowPlayer()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    private void LookOnMouse()
    {
        Vector3 cameraPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        cameraPos.z = -10;
        Vector3 dir = cameraPos - this.transform.position;

        if (player.GetComponent<SpriteRenderer>().isVisible == true)
        {
            transform.Translate(dir * 2 * Time.deltaTime);
        }
    }
}
