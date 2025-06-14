using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject[] gridCells; // Array to hold the grid cells
    public SpriteRenderer xPrefab; // Prefab for X
    public SpriteRenderer oPrefab; // Prefab for O
    public bool isXTurn = true; // by default X starts first and player is always X
    public int occupied = 0; // count of occupied cells

    public bool playing = true;
    bool winner = false;
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
        if (!playing)
        {

        }
        else
        {
            if (isXTurn)
            {
                // it will wait for a mouse input so that isXTurn will change to false after a move
            }
            else
            {
                Bot(); // then it is bot's turn so it will call the Bot method
            }
            checkWin(); // check for win condition
            checkTie(); // check for tie condition
        }
    }

    void Bot() // will select a random cell to play as O
    {
        int randInt = Random.Range(0, 9);
        if (gridCells[randInt] != null && !gridCells[randInt].GetComponent<CellClick>().isOccupied)
        {
            // Debug.Log("Bot playing at cell: " + randInt);
            gridCells[randInt].GetComponent<CellClick>().OnMouseDown(); // simulate a click on the cell
            isXTurn = true; // toggle back to X's turn
        }
        else if (occupied < 9)
        {
            // if occupied, just call bot again
            Bot();
        }
    }

    void checkWin() // every turn it checks a winner
    {
        // if 3 in a row, column or diagonal

        // check rows 
        for (int i = 0; i < 3; i++)
        {
            // get the 3 cells in the i-th row
            CellClick a = gridCells[i * 3].GetComponent<CellClick>();
            CellClick b = gridCells[i * 3 + 1].GetComponent<CellClick>();
            CellClick c = gridCells[i * 3 + 2].GetComponent<CellClick>();

            // check each cell in the i-th row if occupied
            if (a.isOccupied && b.isOccupied && c.isOccupied)
            { // now check if they are same
                if ((a.used == b.used) && (b.used == c.used))
                {
                    // this row won
                    Debug.Log("game ended, winner is: ");
                    if (a.used == 0)
                    {
                        Debug.Log("O");
                    }
                    else
                    {
                        Debug.Log("X");
                    }
                    playing = false; // stop the game
                    winner = true; // set winner to true
                    return; // leave method
                }
            }
        }

        // check diag
        for (int i = 0; i < 2; i++)
        {
            CellClick a;
            CellClick b;
            CellClick c;

            if (i == 0)
            {
                // get the 3 cells in the i-th diag
                a = gridCells[0].GetComponent<CellClick>();
                b = gridCells[4].GetComponent<CellClick>();
                c = gridCells[8].GetComponent<CellClick>();
            }
            else
            {
                a = gridCells[2].GetComponent<CellClick>();
                b = gridCells[4].GetComponent<CellClick>();
                c = gridCells[6].GetComponent<CellClick>();
            }

            // check each cell in the diag if occupied
            if (a.isOccupied && b.isOccupied && c.isOccupied)
            { // now check if they are same
                if ((a.used == b.used) && (b.used == c.used))
                {
                    // this diag won
                    Debug.Log("game ended, winner is: ");
                    if (a.used == 0)
                    {
                        Debug.Log("O");
                    }
                    else
                    {
                        Debug.Log("X");
                    }
                    playing = false; // stop the game
                    winner = true; // set winner to true
                    return; // leave method
                }
            }
        }

        // check cols
        for (int i = 0; i < 3; i++)
        {
            // get the 3 cells in the i-th col
            CellClick a = gridCells[i].GetComponent<CellClick>();
            CellClick b = gridCells[i + 3].GetComponent<CellClick>();
            CellClick c = gridCells[i + 6].GetComponent<CellClick>();

            // check each cell in the i-th col if occupied
            if (a.isOccupied && b.isOccupied && c.isOccupied)
            { // now check if they are same
                if ((a.used == b.used) && (b.used == c.used))
                {
                    // this col won
                    Debug.Log("game ended, winner is: ");
                    if (a.used == 0)
                    {
                        Debug.Log("O");
                    }
                    else
                    {
                        Debug.Log("X");
                    }
                    playing = false; // stop the game
                    winner = true; // set winner to true
                    return; // leave method
                }
            }
        }

        if (occupied == 9) // means all are occupied without passing the winner checks
        {
            Debug.Log("Game ended in a draw!");
            playing = false; // stop the game
            return; // leave method
        }
    }

    void checkTie()
    {
        if (occupied == 9 && !winner) // means all are occupied without passing the winner checks
        {
            Debug.Log("Game ended in a draw!");
            playing = false; // stop the game
        }
    }

}
