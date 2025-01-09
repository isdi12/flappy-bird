using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //el game manager controla las variables del juego y es accesible a todos
    private float time;
    private int points, hits, currentAdd, randomNumberAd;
    private KeyCode Esc = KeyCode.Escape;

    //public AudioClip SelectClip;


    public enum GameManagerVariables { TIME, POINTS };//para facilitar el codigo

    private void Awake()
    {
        if (!instance)
        {
            instance = this;//se instancia el objecto
            DontDestroyOnLoad(gameObject);// no se destruye entre cargas
            randomNumberAd = Random.Range(3, 6);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(Esc))
        {
            SceneManager.LoadScene("Menu");
            AudioManager.instance.ClearAudio();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ExitGame();
        }
    }

    // getter
    public float GetTime()
    {
        return time;
    }

    // getter
    public int GetPoints()
    {
        return points;
    }
    public void SetPoints(int value)
    {
        points = value;
    }

    public int GetHit()
    {
        return hits;
    }

    public void SetHit(int value)
    {
        hits = value;
        if(hits >= randomNumberAd)
        {
            hits = 0;
            AdDisplayManager.instance.ShowAd();
        }
    }

    public void LoadScene(string sceneName)
    {
        time = 0;
        points = 0;
        SceneManager.LoadScene(sceneName);
        AudioManager.instance.ClearAudio();
    }

    public void ExitGame()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }


}

