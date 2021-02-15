// Determines how long an item exists before it's despawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour
{
    public int lifetime;
    
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
