using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int playerMaxHealth;
    public Slider healthSlider;


    private int playerCurrentHealth;

	// Use this for initialization
	void Awake ()
    {
        playerCurrentHealth = playerMaxHealth;
        if (healthSlider != null)
            healthSlider.maxValue = playerMaxHealth;
    }

    // Update is called once per frame
    void Update ()
    {
        if (healthSlider != null)
            healthSlider.value = playerCurrentHealth;
        if (playerCurrentHealth <= 0)
            gameObject.SetActive(false);
	}

    public void DealDamage (int amount)
    {
        playerCurrentHealth -= amount;
    }

    public void RestoreHealth ()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
