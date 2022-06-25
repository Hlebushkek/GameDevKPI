using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmCameraAlarmingState : IAlarmCameraBase
{
    private AlarmCameraStateManager manager;

    public AlarmCameraAlarmingState(AlarmCameraStateManager manager)
    {
        this.manager = manager;
    }
    public void EnterState()
    {
        
    }

    public void ExitState()
    {
       
    }

    public void UpdateState()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void EndAlarming()
    {
        manager.SwitchState(new AlarmCameraPatrolingState(manager));
    }
}
