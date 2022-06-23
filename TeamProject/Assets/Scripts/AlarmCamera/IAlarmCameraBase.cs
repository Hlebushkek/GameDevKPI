using UnityEngine;

public interface IAlarmCameraBase
{
    public void EnterState();
    public void ExitState();
    public void UpdateState();
    public void OnTriggerEnter2D(Collider2D other);
}
