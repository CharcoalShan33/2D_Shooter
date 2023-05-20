using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;

    public GameObject missle;

    private float _offsetY = .5f;

    
    public float fireRate = .5f;
    public bool canFire = true;
    private float timePassed;

    [SerializeField]
    private int _lives = 3;


    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector2(0, 0);
    }


    // Update is called once per frame

    void Update()
    {

        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > timePassed)
        {

            timePassed = Time.time + fireRate;
            canFire = true;
            FireLaser();


        }


    }


    void CalculateMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");


        Vector2 direction = new Vector2(hInput, vInput);

        transform.Translate(direction * 10 * Time.deltaTime);

        //Bounds

        //transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -8f, 8f));
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x, -14f, 14), transform.position.y);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x),
        Mathf.Clamp(transform.position.y, Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y, Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y));
    }
    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missle, transform.position + new Vector3(0, _offsetY, 0), Quaternion.identity);


        }

    }

    public void TakeDamage()
    {
        _lives--;

        Debug.Log("How many Lives Left? " + _lives);

        if(_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

    
   
}