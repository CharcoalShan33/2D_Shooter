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


    private AudioSource audioExplode = null;

  

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();

        audioExplode = GetComponent<AudioSource>();

        _player = GameObject.Find("Player").GetComponent<Player>();

        if(enemyAnim == null)
        {
            Debug.LogError("Add an Animator component");
        }
        if(_player == null)
        {
            Debug.LogError("Find the GameObject");
        }

        if(audioExplode == null)
        {
            Debug.LogError("Find the Audio Source Component");
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
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
                    {
                    _player.TakeDamage();
                    }
            

            enemyAnim.SetTrigger("OnEnemyDeath");
            _enSpeed = 0f;
            audioExplode.Play();
            Destroy(this.gameObject, 2.4f);
            

        }
        else if (other.CompareTag("Laser"))
            {

            Destroy(other.gameObject);

            if (_player != null)
            {
                _player.AddScore(10);
            }
            
            enemyAnim.SetTrigger("OnEnemyDeath");
            _enSpeed = 0f;
            audioExplode.Play();
            Destroy(this.gameObject, 2.4f);

        }
    }
    
}
