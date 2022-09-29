using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    private TurnManager manager;

    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 10;

    public void AssignManager(TurnManager theManager)
    {
        manager = theManager;
    }

    //public void Shooting()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        Shootball();
    //        manager.ChangeTurn();
    //    }
    //}

    //public void Shootball()
    //{
    //    //activeplayer currentplayer = manager 
    //    var ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
    //    ball.GetComponent<Rigidbody>().velocity = ballSpawnPoint.forward * ballSpeed;
    //    //manager.ChangeTurn();
    //}



}
