using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    
    //private SpriteRenderer newSprite;

    private SpriteRenderer newSprite;

    [SerializeField]
    private Sprite[] cSprites;

    public int spriteNum;

    public int loopCycle = 1;

    public int stopLoop = 2;

    private bool isDone = false;
    // Start is called before the first frame update
    void Start()
    {
        newSprite = GetComponent<SpriteRenderer>();

        if (newSprite != null)
        {
            StartCoroutine(ChangeSprite());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ChangeSprite()
    {
        

        while (isDone == false)
        {

            
            newSprite.sprite = cSprites[spriteNum];
            spriteNum++;
            yield return new WaitForSeconds(2f);
        if(spriteNum >= cSprites.Length)
            {
            spriteNum = 0;
                loopCycle++;
             Debug.Log("Loop is done");
              
            
           
            }

        else if (loopCycle == stopLoop)
            {
             
                isDone = true;
                Debug.Log("Done");
            }
        }
       

    }

    

}
