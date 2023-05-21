using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer _renderer;

    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
         yield return StartCoroutine(ColorChange());
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator ColorChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            _renderer.color = ChangeColor();
        }
    }

    Color ChangeColor()
    {
        var _nColor = new Color (Random.value, Random.value, Random.value);

        return _nColor;
    }
}
