using UnityEngine;

public class CharacterPlacer : MonoBehaviour
{
    public GameObject characterPrefab;  // Assign in Inspector
    public Transform tableCenter;       // A child object or empty GameObject on the table
    private GameObject currentCharacter;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentCharacter == null)
        {
            PlaceCharacter();
        }
    }

    void PlaceCharacter()
    {
        currentCharacter = Instantiate(characterPrefab, tableCenter.position, Quaternion.identity);
    }
}
