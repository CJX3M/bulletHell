using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public string target;
    public int damageAmount;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            other.gameObject.GetComponent<Health>().DealDamage(damageAmount);
            gameObject.SetActive(false);
        }
    }
}
