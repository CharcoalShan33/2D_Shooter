using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_LaserMovement : MonoBehaviour
{
    public float speed = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
