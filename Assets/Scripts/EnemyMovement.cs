using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _enSpeed = 5.0f;

    

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * _enSpeed * Time.deltaTime);

        if (transform.position.y < -7.5f)
        {
            float randomX = Random.Range(-13, 13);
            
          
            transform.position = new Vector2(randomX, 7);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();

            if(player != null)
                    {
                    player.TakeDamage();
                     }
           
        }
        else if (other.CompareTag("Laser"))
            {

            P_LaserMovement _laser = other.transform.GetComponent<P_LaserMovement>();

            

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    
}
