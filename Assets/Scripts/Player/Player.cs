using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Shooting")]

    [SerializeField]
    private float fireRate = .5f;

    private float offsetY = .5f;

    private float timePassed;

    [Header("Player")]

    [SerializeField]
    private float _pSpeed = 7f;

    [SerializeField]
    private GameObject missle;

    [SerializeField]
    private GameObject tripleShotMissle;

    [Header("Active Power-Ups")]


    private bool isTripleShotActive;


    private bool isSpeedBoostActive;

    private bool isShieldBoostActive;

    [SerializeField]
    private GameObject shieldVisual;

    private float speedMulitiplier = 2f;

    [Header("UI Elements")]

    [SerializeField]
    private int lives;

    [SerializeField]
    private int _score;

    private UI_Manager uiManager;

    private Spawn spawnManager;

    [Header("Effects")]

    [SerializeField]
    private GameObject leftHitShip;

    [SerializeField]
    private GameObject rightHitShip;


    [Header("Sound")]

    [SerializeField]
    private AudioClip _laserShot;

    private AudioSource _audioSource;



    //[serializeField] private GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn>();
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _audioSource = GetComponent<AudioSource>();

        if (uiManager == null)
        {
            Debug.LogError("UI Manager is Null! Add a UI component.");
        }
        if (spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL! Add a spawn manager component.");
        }

        if(_audioSource == null)
        {
            Debug.LogError("AudioSource is not found! Add an audio source component.");
        }
       



        leftHitShip.SetActive(false);
        rightHitShip.SetActive(false);


       // effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > timePassed)
        {
            FireLaser();
        }
    }
    void FireLaser()
    {
        timePassed = Time.time + fireRate;

        PlaySFXClip(_laserShot);
        //_audioSource.Play();

        if (isTripleShotActive == true)
        {
            Instantiate(tripleShotMissle, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(missle, transform.position + new Vector3(0, offsetY, 0), Quaternion.identity);
        }

        

    }
    public void PlaySFXClip(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }    
  

    void CalculateMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(hInput, vInput);

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), transform.position.y);

        transform.Translate(direction * _pSpeed * Time.deltaTime);
  
    }

    public void TakeDamage()
    {
        if (isShieldBoostActive == true)
        {
            shieldVisual.SetActive(false);

            isShieldBoostActive = false;
            return;
        }

        lives--;

        if(lives == 2)
        {
            rightHitShip.SetActive(true);
        }
        if(lives==1)
        {
            leftHitShip.SetActive(true);
        }

        uiManager.UpdateLives(lives);

        if (lives < 1)
        {
            Destroy(this.gameObject);
            Debug.Log("I am Destroyed");
            spawnManager.OnPlayerDeath();
        }
        else
        {
            Debug.Log("I am hit");
        }
    }

    public void TripleShotActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotCountDown());
    }

    IEnumerator TripleShotCountDown()
    {
        yield return new WaitForSeconds(5f);
        isTripleShotActive = false;
    }

    public void SpeedBoostActive()
    {

        isSpeedBoostActive = true;
        _pSpeed *= speedMulitiplier;
        StartCoroutine(SpeedCountDown());
        //effect.SetActive(true);
    }

    IEnumerator SpeedCountDown()
    {
        yield return new WaitForSeconds(5f);
        _pSpeed /= speedMulitiplier;
        isSpeedBoostActive = false;
       // effect.SetActive(false);
    }

    public void ShieldBoostActive()
    {
        isShieldBoostActive = true;

        shieldVisual.SetActive(true);
    }

    public void AddScore(int points)
    {
        _score += points;
        uiManager.UpdateScore(_score);
        Debug.Log("Add Score");
    }


}
