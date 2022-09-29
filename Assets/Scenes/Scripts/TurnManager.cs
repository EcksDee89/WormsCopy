using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private ActivePlayer playerOne;
    [SerializeField] private ActivePlayer playerTwo;
    //  [SerializeField] private float timeBetweenTurns;

    private ActivePlayer currentPlayer;

    void Start()
    {
        playerOne.AssignManager(this);
        playerTwo.AssignManager(this);

        currentPlayer = playerOne;
    }

    public ActivePlayer GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void ChangeTurn()
    {
        if (playerOne == currentPlayer)
        {
            currentPlayer = playerTwo;
        }
        else if (playerTwo == currentPlayer)
        {
            currentPlayer = playerOne;
        }


    }
}
