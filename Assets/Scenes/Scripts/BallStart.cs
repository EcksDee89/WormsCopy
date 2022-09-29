using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 10;
    [SerializeField] TurnManager manager;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootBall();
            
        }
    }

    public void ShootBall()
    {
        //ActivePlayer currentPlayer = manager 
        ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        var ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
        ball.GetComponent<Rigidbody>().velocity = ballSpawnPoint.forward * ballSpeed;
    }
}
