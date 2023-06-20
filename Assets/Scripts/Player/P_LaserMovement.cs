using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_LaserMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;

 

    // Start is called before the first frame update
    void Start()
    {
       
                
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 4.7f)
        {
           if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }
}