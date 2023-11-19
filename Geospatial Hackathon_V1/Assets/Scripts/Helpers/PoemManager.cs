using System.Collections.Generic;
using UnityEngine;

public class PoemManager : MonoBehaviour
{
    // Dictionary to hold the mapping of GameObjects to Poems
    private Dictionary<GameObject, Poem> poemDictionary = new Dictionary<GameObject, Poem>();

    // Function to assign a poem to an object
    public void AssignPoemToGameObject(GameObject obj, Poem poem)
    {
        if (poemDictionary.ContainsKey(obj))
        {
            // Update the poem for an existing object
            poemDictionary[obj] = poem;
            Debug.Log($"Poem assigned to {obj.name}: {poem.Text}");
        }
        else
        {
            // Add a new object-poem pair
            poemDictionary.Add(obj, poem);
        }
    }

    // Function to get a poem assigned to an object
    public Poem GetPoemFromGameObject(GameObject obj)
    {
        if (poemDictionary.TryGetValue(obj, out Poem poem))
        {
            Debug.Log($"Retrieved poem for {obj.name}: {poem.Text}");
            return poem;
        }
        else
        {
            Debug.Log($"No poem found for {obj.name}");
            return null;
        }
    }
}
