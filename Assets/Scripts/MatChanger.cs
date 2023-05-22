using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatChanger : MonoBehaviour
{
    MeshRenderer mRend;

    bool isDone = false;
    // Start is called before the first frame update
    void Start()
    {
        mRend = GetComponent<MeshRenderer>();

      
        if(mRend != null)
        {
            StartCoroutine(ChangeColors(.2f));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ChangeColors(float delay)

    {
        while (isDone == false)
        {
            Color nColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            
            

            yield return new WaitForSeconds(delay);

            mRend.material.color = nColor;

            if(mRend.material.color == Color.blue)
            {
                isDone = true;
                Debug.Log("Done");
            }
        }
        

    }
}
