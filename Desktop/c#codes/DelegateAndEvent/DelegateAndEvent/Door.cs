using System;
namespace DelegateAndEvent
{
    // the delegate that has bool and return void
    public delegate void DoorAction(bool isOpen);
    public class Door
    {
        // the event based on the DoorAction delegate
        // NB. event are named in the past tense
        // the client/subscribers register for the event DoorOpened using any of thier methods that have same definition like the DoorAction deletegate
        // E.g SetAlarm in Security system has same definition as DoorAction
        public event DoorAction DoorOpened;
        public Door()
        {
        }
        // The method that perform the action that causes the event
        public void Open()
        {
            // calling another method/method after the action is complete to notify the subscribers
            //NB. inside the OnOpened method, the event is invoked like  DoorOpened.Invoke
            OnOpened();
        }
        // The method that perform the action that causes the event similar to Open
        public void Close()
        {
            // calling another method/method after the action is complete to notify the subscribers
            //NB. inside the OnClose method, the event is invoked like  DoorOpened.Invoke
            OnClosed();
        }
        protected virtual void OnOpened()
        {
            DoorOpened.Invoke(true);
        }
        protected virtual void OnClosed()
        {
            DoorOpened.Invoke(false);
        }
    }
}

