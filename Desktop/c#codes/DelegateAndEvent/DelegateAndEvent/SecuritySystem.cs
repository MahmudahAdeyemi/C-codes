using System;
namespace DelegateAndEvent
{
    public class SecuritySystem
    {
        public AlarmState Alarm { get; private set; } = AlarmState.Off;
        public ElectricalFenceState ElectricalFence { get; private set; } = ElectricalFenceState.Off;

        public SecuritySystem()
        {
        }
        public void SetAlarm(bool state)
        {
            Alarm = state ? AlarmState.On : AlarmState.Off;
        }
        public void SetElectricalFence(bool state)
        {
            ElectricalFence = state ? ElectricalFenceState.On : ElectricalFenceState.Off;
        }
       
    }

    public enum AlarmState
    {
        On,
        Off
    }
    public enum ElectricalFenceState
    {
        On,
        Off
    }
}

