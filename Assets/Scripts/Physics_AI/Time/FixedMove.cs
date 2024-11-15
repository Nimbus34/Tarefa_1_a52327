using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMove : MonoBehaviour
{
    public float speed = 0.5f;
    private void FixedUpdate()
    {
        this.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
