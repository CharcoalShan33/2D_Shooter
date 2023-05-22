using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyObject;

    private bool _isPlayerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawning()
    {
        while(_isPlayerDead == false)
        {
            Vector2 position = new Vector2(Random.Range(-8f, 8f), 7);
            Instantiate(_enemyObject, position, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }
    public void OnPlayerDeath()
    {
        _isPlayerDead = true;
        
        
    }
}
