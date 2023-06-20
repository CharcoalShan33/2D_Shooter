using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GameOver()
    {
        isGameOver = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver ==  true)
        {
            RestartLevel();
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
