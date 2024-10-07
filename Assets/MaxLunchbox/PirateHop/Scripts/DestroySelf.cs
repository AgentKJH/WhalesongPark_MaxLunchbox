using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float timeTillDestroyed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroySelfMethod), timeTillDestroyed);
    }

    void DestroySelfMethod() 
    { 
        print("Destroying: " + gameObject.name);
        Destroy(gameObject);
    }
}
