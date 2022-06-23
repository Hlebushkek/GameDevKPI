using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmCameraStateManager : MonoBehaviour
{
    [Header("Vision Field")]
    [SerializeField] private float cameraRotateAngle = 0;

    [Header("Vision Field")]
    [SerializeField] private float visionDistance = 8;
    [SerializeField] private float visionAngleDegree = 30;
    [SerializeField] private int visionColliderPoints= 30;
    [SerializeField] private LayerMask visionLayers;
    [SerializeField] private bool shouldDrawVisionRays = false;
    private Transform rotatingPart;
    private EdgeCollider2D rotatingPartVisionCollider;
    

    private IAlarmCameraBase currentState;

    private void Awake()
    {
        rotatingPart = transform.GetChild(0);
        CreateVisionCollider();

        SwitchState(new AlarmCameraPatrolingState(this));
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }

        UpdateVisionCollider();
    }

    public void SwitchState(IAlarmCameraBase newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = newState;
        currentState.EnterState();
    }


   private void CreateVisionCollider()
    {
        rotatingPartVisionCollider = rotatingPart.gameObject.AddComponent<EdgeCollider2D>();
        rotatingPartVisionCollider.isTrigger = true;

        UpdateVisionCollider();
    }
    private void UpdateVisionCollider()
    {
        float startAngel = rotatingPart.eulerAngles.z - visionAngleDegree / 2;
        float del1taAngel = (float)visionAngleDegree / (visionColliderPoints - 2);
        Vector2 origin = new Vector2(rotatingPart.position.x, rotatingPart.position.y);

        Vector2[] points = new Vector2[visionColliderPoints];

        points[0] = Vector2.zero;
        for (int i = 1; i < visionColliderPoints - 1; i++)
        {
            Vector2 rot = Utilities.DegreeToVector2(startAngel + del1taAngel * (i-1));
            RaycastHit2D raycast = Physics2D.Raycast(origin, rot, visionDistance, visionLayers);
            
            if (raycast.collider)
            {
                if (shouldDrawVisionRays) Debug.DrawRay(origin, rot * visionDistance, Color.red);
                points[i] = Utilities.rotateByDegree(raycast.point - origin, -rotatingPart.eulerAngles.z);
            }
            else
            {
                if (shouldDrawVisionRays) Debug.DrawRay(origin, Utilities.DegreeToVector2(rotatingPart.eulerAngles.z + -visionAngleDegree / 2 + del1taAngel * (i-1)) * visionDistance, Color.blue);
                points[i] = Utilities.rotateByDegree(new Vector2(0, visionDistance), -visionAngleDegree / 2 + del1taAngel * (i-1) - 90);
            }
            
        }
        points[visionColliderPoints-1] = Vector2.zero;

        rotatingPartVisionCollider.points = points;
    }

    public float GetRotateAngel()
    {
        return cameraRotateAngle;
    }
}
