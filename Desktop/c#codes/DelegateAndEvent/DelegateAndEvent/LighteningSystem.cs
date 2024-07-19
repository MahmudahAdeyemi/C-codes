using System.Diagnostics;

namespace DelegateAndEvent
{
    public delegate void LightAction(bool IsOn);
    public class LighteningSystem
    {
        public event LightAction LightOn;
        public LighteningSystem()
        {
        }

        public LightState Light{get; set;}
        
        public void OnLight(bool state)
        {
           Light = state ? LightState.On : LightState.Off;
        }
        public void On()
        {
            SwitchedOn();
        }
        public void Off()
        {
            SwitchedOff();
        }
        protected virtual void SwitchedOn()
        {
            LightOn.Invoke(false);
        } 

        protected virtual void SwitchedOff()
        {
            LightOn.Invoke(true);
        }

        
    }
    public enum LightState
    {
        On,
        Off
    }
}