using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomColor : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }
}
