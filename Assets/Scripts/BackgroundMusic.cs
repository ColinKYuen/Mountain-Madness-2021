// Play game music

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgkroundMusic : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
