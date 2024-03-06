using System.Collections.Generic;
using UnityEngine;

public enum ArrowDirection
{
    Up,
    Down,
    Left,
    Right
}

public class wattahgame_ArrowInputRecorder : MonoBehaviour
{
    public GameObject player1UI;
    public GameObject player2UI;

    private List<ArrowDirection> player1Inputs = new List<ArrowDirection>();
    private List<ArrowDirection> player2Inputs = new List<ArrowDirection>();

    private int currentPlayer = 1;
    private int inputCount = 0;
    private int mismatches = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddInput((currentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AddInput((currentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddInput((currentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddInput((currentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Right);
        }

        if (player1Inputs.Count >= 4 && player2Inputs.Count >= 4)
        {
            CompareInputs();
            player1Inputs.Clear();
            player2Inputs.Clear();
            currentPlayer = 1;
            inputCount = 0;
            mismatches = 0;
        }
    }

    void AddInput(List<ArrowDirection> inputList, ArrowDirection direction)
    {
        inputList.Add(direction);
        UpdateUI((currentPlayer == 1) ? player1UI : player2UI, direction);

        Debug.Log("Player " + currentPlayer + " Input: " + direction);

        if (currentPlayer == 2 && player1Inputs.Count > inputCount && player1Inputs[inputCount] == direction)
        {
            Debug.Log("Player 1 and Player 2 matched at input " + inputCount);
        }
        else if (currentPlayer == 2)
        {
            Debug.Log("Mismatch at input " + inputCount + ". Player 1: " + player1Inputs[inputCount] + ", Player 2: " + direction);
            mismatches++;
        }

        inputCount++;
        if (inputCount >= 4)
        {
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
            inputCount = 0;
        }
    }

    void UpdateUI(GameObject playerUI, ArrowDirection direction)
    {
        // 矢印のUIを表示する処理
    }

    void CompareInputs()
    {
        Debug.Log("Mismatch Count: " + mismatches);
    }
}
