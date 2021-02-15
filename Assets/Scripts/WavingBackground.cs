// Move the sky and sea in background

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavingBackground : MonoBehaviour
{
    private bool direction = false;
    private float duration = 0;

    void Update()
    {
        if (duration >= 600) {
            direction = !direction;
            duration = 0;
        }

        if (direction) {
            transform.Translate(Time.deltaTime * 0.25f, 0, 0);
        } else {
            transform.Translate(-Time.deltaTime * 0.25f, 0, 0);
        }
        duration += 1;
    }
}
