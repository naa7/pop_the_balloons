using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject controller;
    [SerializeField] InputField playerNameInput;
    [SerializeField] int level;
    [SerializeField] int score = 0;

    void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (pauseButton == null)
        {
            pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
        }
        if (resumeButton == null)
        {
            resumeButton = GameObject.FindGameObjectWithTag("ResumeButton");
        } 

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        playerName = playerNameInput.text;
        PersistentData.Instance.SetName(playerName);
        PersistentData.Instance.SetScore(score);
        SceneManager.LoadScene("Level 1");
    }

    public void nextLevel() {
        if (level == 5)
            SceneManager.LoadScene("Level 2");
        else {
            SceneManager.LoadScene("Level 3");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

     public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ResetHighScores()
    {
        PlayerPrefs.DeleteAll();
        PersistentData.Instance.SetScore(score);
        PersistentData.Instance.SetName("");
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }
}
