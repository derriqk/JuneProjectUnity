using UnityEngine;

public class CellClick : MonoBehaviour
{
    public GameObject xPrefab; // x prefab
    public GameObject oPrefab; // o prefab
    public TicTacToe board; // lets it reference the board script
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
        // testing
        // Debug.Log("Cell clicked: " + gameObject.name + ", isOccupied: " + isOccupied);

        if (!isOccupied)
        {
            GameObject prefabToInstantiate = null;

            if (board.isXTurn)
            {
                prefabToInstantiate = xPrefab;
                // then spawn the prefab at the cell's position
                if (prefabToInstantiate != null)
                {
                    // test
                    // Debug.Log("Instantiating prefab: " + prefabToInstantiate.name);
                    GameObject newObject = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
                    newObject.transform.SetParent(transform);
                }
            }
            else
            {
                prefabToInstantiate = oPrefab;
                // then spawn the prefab at the cell's position
                if (prefabToInstantiate != null)
                {
                    // test
                    // Debug.Log("Instantiating prefab: " + prefabToInstantiate.name);
                    GameObject newObject = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
                    newObject.transform.SetParent(transform);
                }
            }
            board.isXTurn = !board.isXTurn; // toggle turn
            isOccupied = true; // mark cell occupied
        }
        // test
        // else
        // {
        //     Debug.Log("Cell is already occupied: " + gameObject.name);
        // }
    }
}
