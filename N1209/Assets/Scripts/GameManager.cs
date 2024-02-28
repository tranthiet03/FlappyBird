using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(gameObject);
        Time.timeScale = 0;
        isStart = false;
        UpdateUIScore();
        btnStart.onClick.AddListener(() =>
        {
            GameStart();
            btnStart.gameObject.SetActive(false);
        });
        btnRestart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
    private bool isStart = false;
    private void GameStart()
    {
        isStart = true;
        Time.timeScale = 1;
    }
    public bool IsStartGame() => isStart;
    [Space(10), Header("UI")]
    [SerializeField] Text txtScore;
    [SerializeField] Text txtCurScore;
    [SerializeField] Text txtHighScore;
    [SerializeField] Button btnStart;
    [SerializeField] Button btnRestart;
    [SerializeField] GameObject GameOverPanel;
    private int curScore;
    public void AddPoint()
    {
        curScore++;
        UpdateUIScore();
    }
    private int HighScore
    {
        get => PlayerPrefs.GetInt("HighScore", 0);
        set
        {
            if (value > PlayerPrefs.GetInt("HighScore", 0))
                PlayerPrefs.SetInt("HighScore", value);
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        HighScore = curScore;
        GameOverPanel.SetActive(true);
        txtCurScore.text = string.Format($"Score: {curScore}");
        txtHighScore.text = string.Format($"HighScore: {HighScore}");
    }
    private void UpdateUIScore()
    {
        txtScore.text = curScore.ToString();
    }
}
