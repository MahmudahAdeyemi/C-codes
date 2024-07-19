var eventhandler = new EventExample.EventHandler();
eventhandler.Open += Alarm;
static void Alarm(object OpenDoor,bool condition)
{
    Console.WriteLine("Alarm");
}
