using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private Transform playerShip;
    // Use this for initialization

    void Update()
    {
        transform.LookAt(playerShip);
        GetComponent<EnemyShot>().fire = !(gameObject.transform.position.z <= -3 || !gameObject.GetComponent<Health>().IsAlive());
    }

    public void SetPlayerShip(Transform _playerShip)
    {
        playerShip = _playerShip;
    }
}
