namespace DelegateAndEvent
{
    public class WaterPumping
    {
        public WaterPump Water{get; set;}
        public WaterPumping()
        {
        }
        public void IfWaterPump(bool state)
        {
           Water = state ? WaterPump.Off : WaterPump.On;
        }
    }
    public enum WaterPump
        {
            On,
            Off
        }
}