using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int playerMaxHealth;
    public Slider healthSlider;
    public GameObject explosionAnim;

    private GameController gameController;
    private int playerCurrentHealth;

    private void Start()
    {
        GameObject _gameController = GameObject.FindGameObjectWithTag("GameController");
        if (_gameController != null)
            gameController = _gameController.GetComponent<GameController>();
        if (_gameController != null)
            Debug.Log("The object 'GameController' is null");
    }

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
        {
            gameObject.SetActive(false);
            Instantiate(explosionAnim, gameObject.transform.position ,gameObject.transform.rotation);
            gameController.UpdateScore(GetComponent<Mover>().points);
        }
	}

    public void DealDamage (int amount)
    {
        playerCurrentHealth -= amount;
    }

    public void RestoreHealth ()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public bool IsAlive()
    {        
        return playerCurrentHealth > 0;
    }
}
