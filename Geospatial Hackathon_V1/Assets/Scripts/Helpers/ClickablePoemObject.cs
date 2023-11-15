using UnityEngine;

public class ClickablePoemObject : MonoBehaviour
{
    private PoemManager _poemManager;

    private void Start()
    {
        // Find the PoemManager instance in the scene
        _poemManager = FindObjectOfType<PoemManager>();

        if (_poemManager == null)
        {
            Debug.LogError("PoemManager not found in the scene.");
        }
    }

    private void OnMouseDown() // This function is called when the object is clicked
    {
        if (_poemManager != null)
        {
            Poem poem = _poemManager.GetPoemFromGameObject(gameObject);
            if (poem != null)
            {
                Debug.Log(poem.Text); // Print the poem to the console
            }
            else
            {
                Debug.Log("No poem assigned to this object.");
            }
        }

    }
}
