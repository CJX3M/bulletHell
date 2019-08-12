using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", 2f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

}
