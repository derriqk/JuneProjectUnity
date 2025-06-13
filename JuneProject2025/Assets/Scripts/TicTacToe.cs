using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject[] gridCells; // Array to hold the grid cells
    public SpriteRenderer xPrefab; // Prefab for X
    public SpriteRenderer oPrefab; // Prefab for O
    public bool isXTurn = true; // by default X starts first and player is always X
    void Start()
    {
        gridCells = new GameObject[9]; // 9 cells

        for (int i = 0; i < gridCells.Length; i++)
        {
            gridCells[i] = GameObject.Find("Cell" + i);
            if (gridCells[i] == null)
            {
                Debug.LogError("Cell" + i + " not found in the scene. Please ensure all cells are named correctly.");
            }
            else
            {
                // Debug.Log("Cell" + i + " found successfully.");
                // initialize the cell components
                gridCells[i].AddComponent<CellClick>(); // add CellClick component to each cell
                gridCells[i].AddComponent<BoxCollider2D>(); // add 2D collider to each cell
                gridCells[i].GetComponent<CellClick>().xPrefab = xPrefab.gameObject; // assign xPrefab
                gridCells[i].GetComponent<CellClick>().oPrefab = oPrefab.gameObject; // assign oPrefab
                gridCells[i].GetComponent<CellClick>().board = this; // assign the TicTacToe board reference
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
