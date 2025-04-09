using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    Vector2 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(0.01f, 0.05f)]
    public float parallaxSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
