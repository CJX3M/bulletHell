using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private Transform playerShip;
    // Use this for initialization

    void Update()
    {
        Debug.Log("Player position " + playerShip);
        Vector3 toTarget = playerShip.position - transform.position;
        Debug.Log("Current rotation " + transform.rotation);
        //transform.rotation = Quaternion.LookRotation(Vector3.down, toTarget);
        transform.LookAt(playerShip);
        Debug.Log("Actual rotation " + transform.rotation);
    }

    public void SetPlayerShip(Transform _playerShip)
    {
        playerShip = _playerShip;
    }
}
