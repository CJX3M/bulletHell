using System.Collections;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.tag)
        {
            case "Bullet":
                Debug.Log("A bullet reached the killbox");
                other.gameObject.SetActive(false);
                break;
            case "Enemie":
                Debug.Log("An Enemy reached the killbox");
                other.gameObject.SetActive(false);
                break;
            default:
                Debug.Log($"{other.gameObject.transform.parent.gameObject.name} reached the killbox");
                break;
        }
    }
}
