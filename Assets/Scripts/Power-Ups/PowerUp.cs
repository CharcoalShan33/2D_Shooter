using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _Speed = 3f;

    [SerializeField]
    private int powerUpId;

    [SerializeField]
    private AudioClip _pClip;

    [SerializeField]
    private GameObject _audio;

    //private AudioManager aManager;
    
    void Start()
    {
        //aManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();

       // _audio.AddComponent<DestroyAnything>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.down * _Speed * Time.deltaTime);

        if (transform.position.y < -4.7f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //aManager.PlayClip(_pClip);

        //AudioSource.PlayClipAtPoint(_pClip, transform.position);

        Instantiate(_audio, transform.position, Quaternion.identity);


        if (other.tag == "Player")
        {
            

            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerUpId)
                {
                    case 0:
                        player.TripleShotActive();
                        Debug.Log("Collected TripleShot");
                        break;

                    case 1:
                        player.SpeedBoostActive();
                        Debug.Log("Collected SpeedBoost");
                        break;

                    case 2:
                        player.ShieldBoostActive();
                        Debug.Log("Collected ShieldBoost");
                        break;

                }
                
            }

        }
        Destroy(this.gameObject);
        
    }
}
