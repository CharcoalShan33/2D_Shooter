using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _score_Text;

    [SerializeField]
    private Image _livesImage;

    [SerializeField]
    private Sprite[] lifeSprites;

    [SerializeField]
    private TMP_Text _gameOverText;

    [SerializeField]
    private TMP_Text _restartText;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _score_Text.text = "Score: ";

        _gameOverText.gameObject.SetActive(false);

        _restartText.gameObject.SetActive(false);

        gameManager = GameObject.Find("game_manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateScore(int playerScore)
    {
        _score_Text.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = lifeSprites[currentLives];

        if(currentLives == 0)
        {
            GameOverSequence();
        }

    }
    void GameOverSequence()
    {
        gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
        _restartText.gameObject.SetActive(true);
    }

    IEnumerator GameOverFlicker()
    {
        while(true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(.5f);
        }
    }

   
}
