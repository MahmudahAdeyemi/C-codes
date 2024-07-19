namespace EventExample
{
    public delegate void OpenDoor(object source,bool condition)

    public class EventHandler
    {
        public event OpenDoor Open;
        public void OpenDoor()
        {
            Open.Invoke(this,true);
        }
        protected virtual void OpenEvent()
        {
            Open.Invoke(this,true)
        }
    }
}