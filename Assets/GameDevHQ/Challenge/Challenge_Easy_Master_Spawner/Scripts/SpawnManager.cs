using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    public float delay;

    public int objSpawnNum;


  
     void Start()
    {

        delay = 2f;
     
       StartCoroutine(MakeSpawn());
    }
    private void Update()
    {

        
    }

   IEnumerator  MakeSpawn()
    {
        while (true)
        {
            
           GameObject clone = Instantiate(objectsToSpawn[Random.Range(0, objSpawnNum)], Vector3.down, Quaternion.identity);
            objSpawnNum = objectsToSpawn.Length;
            yield return new WaitForSeconds(delay);
         
           
            Destroy(clone);
                
            


           
        }

       
       
    }

}
