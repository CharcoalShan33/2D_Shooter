using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Enemy")]

    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _enemyObject;


    [Header("Power-Ups")]
    [SerializeField]
    private GameObject[] powerUp;

    private bool _isPlayerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpawning()
    {
        yield return new WaitForSeconds(3.0f);

        while (_isPlayerDead == false)
        {
            Vector2 enemyPosition = new Vector2(Random.Range(-8f, 8f), 7);
           GameObject NewEnemy = Instantiate(_enemyObject, enemyPosition, Quaternion.identity);
           NewEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);

        }
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(3.0f);
        while (_isPlayerDead == false)
        {
            Vector2 powerPosition = new Vector2(Random.Range(-8f, 8f), 7);

            int randomValue = Random.Range(0, 3);
            Instantiate(powerUp[randomValue], powerPosition, Quaternion.identity);
          
            yield return new WaitForSeconds(Random.Range(3,8));
        }
       
    }

   public void StartSpawning()
    {

        StartCoroutine(EnemySpawning());

        StartCoroutine(SpawnPowerUp());

    }

    
    public void OnPlayerDeath()
    {
        _isPlayerDead = true;
        
        
    }
}
