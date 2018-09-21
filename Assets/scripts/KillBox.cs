using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject != null)
            Destroy(other.gameObject.transform.parent.gameObject);
        else
            Destroy(other.gameObject);
    }
}
