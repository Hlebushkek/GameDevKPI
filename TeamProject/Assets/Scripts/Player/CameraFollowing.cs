using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private bool followTarget = true;
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;
    
    private PlayerMovement playerMovement;
    private Camera cam;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;
        target = player;

        cam = this.GetComponent<Camera>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            followTarget = false;
            playerMovement.SetMoving(false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            followTarget = true;
            playerMovement.SetMoving(true);
        }

        if (followTarget)
        {
            FollowTarget();
        }
        else
        {
            LookOnMouse();
        }
    }

    private void FollowTarget()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    private void LookOnMouse()
    {
        Vector3 cameraPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        cameraPos.z = -10;
        Vector3 dir = cameraPos - this.transform.position;
    
        if (player.GetComponent<SpriteRenderer>().isVisible == true)
        {
            transform.Translate(dir * Time.deltaTime);
        }
    }
}
