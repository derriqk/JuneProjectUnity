using UnityEngine;

public class CellClick : MonoBehaviour
{
    public GameObject xPrefab; // x prefab
    public GameObject oPrefab; // o prefab
    bool isOccupied = false; // initially not occupied
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        // Check if the cell is already occupied
        if (!isOccupied)
        {
            // make the asset visible

            // make cell occupied
            isOccupied = true;

        }
        else
        {
            Debug.Log("Cell is already occupied. Please choose another cell.");
        }
    }
}
