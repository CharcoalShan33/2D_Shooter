using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSpawn : MonoBehaviour
{
   
    public GameObject prefab;
    public Transform other;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Appear();
        }
    }

    void Appear()
    {
       

        for(int i = 0; i < 5; i++)
        {
            GameObject sp = Instantiate(prefab, new Vector3(i * 1f,1f,1f), Quaternion.identity);
;
        }
    }
}
