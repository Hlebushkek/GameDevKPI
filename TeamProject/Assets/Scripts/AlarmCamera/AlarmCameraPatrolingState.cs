using UnityEngine;

public class AlarmCameraPatrolingState : IAlarmCameraBase
{
    private AlarmCameraStateManager manager;
    private Transform cameraRotatingPart;

    private float rotateOrigin = 0;
    private float rotateDelta = 0;
    private float rotateTarget = 0;
    private float rotatingSpeed = 20;

    public AlarmCameraPatrolingState(AlarmCameraStateManager manager)
    {
        this.manager = manager;
    }

    public void EnterState()
    {
        cameraRotatingPart = manager.transform.GetChild(0);
        rotateOrigin = cameraRotatingPart.eulerAngles.z;
        rotateDelta = manager.GetRotateAngel();
        rotateTarget = rotateOrigin + rotateDelta;
    }

    public void ExitState()
    {
        
    }

    public void UpdateState()
    {
        RotateCamera();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            EventManager.AlarmEnemyInRadius(manager.transform.position);
        }

        manager.SwitchState(new AlarmCameraAlarmingState());
    }


    private void RotateCamera()
    {
        cameraRotatingPart.rotation = Quaternion.RotateTowards(cameraRotatingPart.rotation, Quaternion.Euler(0, 0, rotateTarget), Time.deltaTime * rotatingSpeed);
        float delta = Mathf.Abs(cameraRotatingPart.transform.eulerAngles.z - rotateTarget);
        if (cameraRotatingPart.transform.eulerAngles.z > 180) delta =Mathf.Abs(delta - 360);

        if (delta < 0.5f)
        {
            rotateDelta *= -1;
            rotateTarget = rotateOrigin + rotateDelta;
        }
    }
}
