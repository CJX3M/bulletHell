using System.Collections;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Bullet":
                Debug.Log("A bullet reached the killbox");
                other.gameObject.transform.parent.gameObject.SetActive(false);
                break;
            case "Enemy(Clone)":
                Debug.Log("An Enemy reached the killbox");
                other.gameObject.SetActive(false);
                break;
            default:
                Debug.Log($"{other.gameObject.name} reached the killbox");
                break;
        }
    }
}
