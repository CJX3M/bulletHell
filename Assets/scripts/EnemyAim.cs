using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private Transform playerShip;
    // Use this for initialization

    void Update()
    {
        //Vector3 toTarget = playerShip.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(Vector3.down, toTarget);
        transform.LookAt(playerShip);
    }

    public void SetPlayerShip(Transform _playerShip)
    {
        playerShip = _playerShip;
    }
}
