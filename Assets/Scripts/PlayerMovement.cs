using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
      
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

       float hInput = Input.GetAxis("Horizontal");
       float vInput = Input.GetAxis("Vertical");


        Vector2 direction = new Vector2(hInput, vInput);

        transform.Translate(direction * speed * Time.deltaTime);

        //Bounds

        //transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -8f, 8f));
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x, -14f, 14), transform.position.y);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x,Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x),
        Mathf.Clamp(transform.position.y, Camera.main.ViewportToWorldPoint(new Vector2(0,0)).y, Camera.main.ViewportToWorldPoint(new Vector2(0,1)).y));
    }

}
