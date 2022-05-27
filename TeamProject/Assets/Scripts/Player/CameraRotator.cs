using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private float mod = 0.01f;
    private float zVal = 0.0f;
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.IsMoving())
        {
            Vector3 rot = new Vector3(0, 0, zVal);
            transform.eulerAngles = rot;

            zVal += mod;

            if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f)
            {
                mod = -0.01f;
            }
            else if (transform.eulerAngles.z < 355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.01f;
            }
        }
    }
}
