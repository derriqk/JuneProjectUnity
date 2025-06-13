using UnityEngine;

public class CellClick : MonoBehaviour
{
    public GameObject xPrefab; // x prefab
    public GameObject oPrefab; // o prefab
    public TicTacToe board; // lets it reference the board script
    public bool isOccupied = false; // initially not occupied
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        // testing
        // Debug.Log("Cell clicked: " + gameObject.name + ", isOccupied: " + isOccupied);

        if (!isOccupied) // check if the cell is not occupied and it's X's turn
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
            else // o turn
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
            isOccupied = true; // mark cell occupied
            board.isXTurn = !board.isXTurn; // toggle turn
        }
        else
        {
            Debug.Log("Cell is already occupied or it's not X's turn.");
        }
    }

    public void click()
    {
        GameObject prefabToInstantiate = null;

        prefabToInstantiate = oPrefab;
        // then spawn the prefab at the cell's position
        if (prefabToInstantiate != null)
        {
        // test
        // Debug.Log("Instantiating prefab: " + prefabToInstantiate.name);
        GameObject newObject = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
        newObject.transform.SetParent(transform);
        }
        board.isXTurn = !board.isXTurn; // toggle turn
        isOccupied = true; // mark cell occupied
    }
}
