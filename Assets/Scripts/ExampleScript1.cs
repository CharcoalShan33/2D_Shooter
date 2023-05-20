using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered" + other.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("What Hit ME" + collision.transform.name);
    }

    private void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(hInput, vInput, 0);

        transform.Translate(dir * 8 * Time.deltaTime);
    }
}
