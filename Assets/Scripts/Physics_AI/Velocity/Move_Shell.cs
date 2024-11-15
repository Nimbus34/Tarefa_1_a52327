using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Shell : MonoBehaviour
{

    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, speed * Time.deltaTime * 0.5f, speed * Time.deltaTime);
    }
}
