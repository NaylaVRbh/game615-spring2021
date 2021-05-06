using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Numeric Variables
    private int LapsRemaining = 3;
    private float GameTime = 20f;


    //Text Variables
    [SerializeField] private Text TimeText;
    [SerializeField] private Text LapsTxt;

    //GameObject Variables
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject GameWin;

    [SerializeField] private AudioSource GameWinSound;

    private void Start()
    {
        TimeText.text = "Time Remaining:" + GameTime + "s";

        Time.timeScale = 1;
    }

    void Update()
    {
        SetTime();

        if(GameTime <= 0 && LapsRemaining > 0)
        {
            setGameOver();
            Debug.Log("Game Over :(");
        }
        else if(GameTime >= 0 && LapsRemaining <= 0)
        {
            setGameWin();
            GameWinSound.Play();
            Debug.Log("You Win!");
        }

    }

    private void SetTime()
    {
        TimeText.text = "Time Remaining:" + (int)GameTime + "s";
        GameTime -= Time.deltaTime;

        if(GameTime <= 0)
        {
            GameTime = 0;
            setGameOver();
        }

    }

    public int setLaps(int param)
    {
        return LapsRemaining -= param;
    }

    public void setGameOver()
    {
        GameOver.SetActive(true);
        GameWin.SetActive(false);
        Time.timeScale = 0;
    }

    public void setGameWin()
    {
        GameOver.SetActive(false);
        GameWin.SetActive(true);
        Time.timeScale = 0.3f;
        GameTime = 0;
    }

    public int getLapsRemaining()
    {
        Debug.Log("Laps Remaining" + LapsRemaining);
        return LapsRemaining;
    }

    public void setLapsGUI()
    {
        int currentlaps = getLapsRemaining();
        LapsTxt.text = "Laps/ "+ currentlaps;
    }

    public void ReplyGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
