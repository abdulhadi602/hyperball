using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject Gamestart, Gameover,Player,GameOverCanvas,Pause;
    
    private ParticleEffectManager peManager;

    public Text score, highScore;
    public GameObject ScoreManagerobj;
    private Score scoreSC;

    private static bool isRestart;

    public List<Vector2> fingerPositions;

    private AudioSource BackGroundMusic;
     void Start()
    {
        BackGroundMusic = GameOverCanvas.GetComponent<AudioSource>();
        if (!isRestart) { 
        Gamestart.SetActive(true);
  
            Player.SetActive(false);
            BackGroundMusic.Stop();
        }
        else
        {
            StartGame();
        }
        peManager = Player.GetComponent<ParticleEffectManager>();
        scoreSC = ScoreManagerobj.GetComponent<Score>();
    }

  

    void Update()
    {
        if (Gamestart.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > 3f)
                {
                   StartGame();
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();

        }
    }

    public void PauseGame()
    {
        if(!Gamestart.activeSelf){
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void CreateLine()
    {
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void GameOver()
    {
       
        Player.SetActive(false);
        Gameover.SetActive(true);
        setFinalScore();
    }

    private void setFinalScore()
    {       
        score.text = "Final Score: " + scoreSC.GetScore();
        highScore.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    public void GameRestart(bool RestartFromSameScore)
    {
        if (!RestartFromSameScore)
        {
            scoreSC.SetScore(0);
        }
        Player.SetActive(true);
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void StartGame()
    {
        Player.SetActive(true);
        Gamestart.SetActive(false);
        BackGroundMusic.Play();
    }
    public void SetEffect1()
    {
        peManager.SetEffect1();
        UnPauseGame();
    }
    public void SetEffect2()
    {
        peManager.SetEffect2();
        UnPauseGame();
    }
    public void SetEffect3()
    {
        peManager.SetEffect3();
        UnPauseGame();
    }
    public void UnPauseGame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PrivacyPolicy()
    {
        Application.OpenURL("https://ahadi3608.wixsite.com/hyperball");
    }
}
