using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null)
        {
            switch (other.name)
            {
                case "Bullet":
                    Destroy(other.gameObject.transform.parent.gameObject);
                    break;
                default:
                    Destroy(other.gameObject);
                    break;
            }
        }
    }
}
