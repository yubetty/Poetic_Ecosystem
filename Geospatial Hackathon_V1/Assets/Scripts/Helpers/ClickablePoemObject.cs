using UnityEngine;
using UnityEngine.EventSystems;

public class ClickablePoemObject : MonoBehaviour
{
    // Define a delegate that takes a string parameter (the unique name of the object)
    public delegate void ObjectClickedAction(string uniqueName);

    // Define an event based on the delegate
    public static event ObjectClickedAction OnObjectClicked;

    private void OnMouseDown() // This function is called when the object is clicked
    {
        // Check if the current pointer is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // If it's over a UI element, do nothing (return)
            return;
        }

        // Get the UniqueIdentifier component
        UniqueIdentifier uniqueIdentifier = GetComponent<UniqueIdentifier>();
        if (uniqueIdentifier != null)
        {
            // Invoke the event with the unique name of this object
            OnObjectClicked?.Invoke(uniqueIdentifier.objectId);
        }
        else
        {
            Debug.LogError("UniqueIdentifier component not found on this GameObject.");
        }
    }
}
