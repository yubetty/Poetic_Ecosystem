using UnityEngine;

public class ClickEvent
{
    // Define a delegate that takes a string parameter (the name of the object)
    public delegate void ObjectClickedAction(string objectName);

    // Define an event based on the delegate
    public static event ObjectClickedAction OnObjectClicked;

    // Method to invoke the event
    public static void ObjectClicked(string objectName)
    {
        OnObjectClicked?.Invoke(objectName);
    }
}