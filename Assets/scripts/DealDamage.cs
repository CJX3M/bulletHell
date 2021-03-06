﻿using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public string target;
    public int damageAmount;
    public GameObject damageAnim;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target)
        {
            gameObject.SetActive(false);            
            other.gameObject.GetComponent<Health>().DealDamage(damageAmount);
            Instantiate(damageAnim, other.gameObject.transform.position, damageAnim.transform.rotation);
        }
    }
}
