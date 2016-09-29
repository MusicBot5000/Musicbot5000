#Comm test README

#1. Unity

Run unity and open a project. Add the Comms.cs file into the Assets folder. Once it has been added, with your mouse, click on the Comms.cs file and drag it to one of your objects in your objects side bar.

You will need to enable the "Api Compatibility Level" to be set to .NET 2.0 rather than .NET 2.0 (subset) for the serial communications. You should be able to find the location of it by googling it.

Run the project.

#2. Arduino

rig up the arduino in whatever setup you want

If you have the motorshield, upload the project to the arduino

If you do not have the motorshield, you will have to modify the code to suit your setup.

#3. Play!

Once both the Arduino Sketch and the Unity project are running, click on the scene in Unity to put the game in focus. press the up arrow key to send data to the arduino.

This should make the arduino trigger the solenoid.
