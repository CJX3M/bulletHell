using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public string target;
    public int damageAmount;
    public GameObject damageAnim;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name} {gameObject.tag} damage {other.gameObject.tag} {other.gameObject.name}");
        Debug.Log($"{gameObject.name} target {target}");
        if (other.gameObject.tag == target)
        {
            gameObject.SetActive(false);            
            other.gameObject.GetComponent<Health>().DealDamage(damageAmount);
            Instantiate(damageAnim, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
    }
}
