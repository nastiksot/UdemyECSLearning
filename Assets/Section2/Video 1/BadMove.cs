using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMove : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate(0f,0f,0.1f );
        if (transform.position.z < 50) return;
        var newPosition = new Vector3(transform.position.x, transform.position.y, -50f);
        transform.position = newPosition;
    }
}
