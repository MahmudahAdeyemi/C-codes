// See https://aka.ms/new-console-template for more information
using DelegateAndEvent;

//Create a door
var door = new Door();
//Create a security system
var securitySystem = new SecuritySystem();
//Register or Subscribe alarm to Door Opened event of the door
door.DoorOpened += securitySystem.SetAlarm;
//Register or Subscribe electrical fence to Door Opened event of the door
door.DoorOpened += securitySystem.SetElectricalFence;
var lighteningSystem = new LighteningSystem();
door.DoorOpened += lighteningSystem.OnLight;
var waterPump = new WaterPumping();
lighteningSystem.LightOn += waterPump.IfWaterPump;

// Open the door 
door.Open();

// Check the securty system if the alarm is on and electrical fence is on because the door is open

Console.WriteLine($"Alarm is {securitySystem.Alarm}");
Console.WriteLine($"Electrical Fence is {securitySystem.ElectricalFence}");

