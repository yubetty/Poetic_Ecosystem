using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Assign your 4 GameObjects in the Unity Editor
    private int nextObjectIndex = 0; // Tracks which object to activate next

    public void ActivateNextObject()
    {
        // Check if there are still objects to activate
        if (nextObjectIndex < objectsToActivate.Length)
        {
            objectsToActivate[nextObjectIndex].SetActive(true); // Activate the next object
            nextObjectIndex++; // Increment the index for the next click
        }
        else
        {
            Debug.Log("All objects have been activated");
            // Optionally, disable the button here if you don't want it to be clickable after all objects are active
            // this.GetComponent<Button>().interactable = false;
        }
    }
}
