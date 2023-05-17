using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        // establishing the position at the start
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

       float hInput = Input.GetAxis("Horizontal");
       float vInput = Input.GetAxis("Vertical");


        Vector2 direction = new Vector2(hInput, vInput);

        transform.Translate(direction * speed * Time.deltaTime);
    }

}
