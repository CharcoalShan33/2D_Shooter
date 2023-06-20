using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _enSpeed = 5.0f;

    [SerializeField]
    private Player _player;

    private Animator enemyAnim;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();

        _player = GameObject.Find("Player").GetComponent<Player>();

        if(enemyAnim == null)
        {
            Debug.LogError("Add an Animator component");
        }
        if(_player == null)
        {
            Debug.LogError("Find the GameObject");
        }

        if (_audio == null)
        {
            Debug.LogError("AudioSource is not found! Add an audio source component.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enSpeed * Time.deltaTime);

        if (transform.position.y < -4f)
        {
            float randomX = Random.Range(-9f, 9f);
            
          
            transform.position = new Vector2(randomX, 7);
        }

        

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
         
        if (other.CompareTag("Player"))
        {
            enemyAnim.SetTrigger("OnEnemyDeath");
            _enSpeed = 0f;
            Destroy(this.gameObject, 2.4f);
            Debug.Log("Destroyed....");

            Player player = other.transform.GetComponent<Player>();
            if(player != null)
                    {
                    _player.TakeDamage();
                    }
           
        }
        else if (other.CompareTag("Laser"))
            {
            
            Debug.Log("Destroyed by a Laser");

            Destroy(other.gameObject);

            if(_player != null)
            {
                _player.AddScore(10);
            }

            enemyAnim.SetTrigger("OnEnemyDeath");
            _enSpeed = 0f;
            Destroy(this.gameObject, 2.4f);

        }
    }
    
}
