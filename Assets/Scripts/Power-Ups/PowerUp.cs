using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _Speed = 3f;

    [SerializeField]
    private int powerUpId;

    // Start is called before the first frame update
    void Start()
    {

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
