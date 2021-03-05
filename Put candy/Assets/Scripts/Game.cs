using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int CountCandies = 8;
    public GameObject Top;
    public Text text;
    public GameObject WinPS;
    public GameObject RestartWindow;
    private int countCandiesInPlace = 0;

    public  void PutCandyInPlace()
    {
        countCandiesInPlace += 1;
        if(countCandiesInPlace>= CountCandies)
        {
            Win();
        }
    }
    private void Win()
    {
        Top.SetActive(true);
        text.text = "Done!";
        Invoke("winPs", 1.7f);
    }
    private void winPs()
    {
        WinPS.SetActive(true);
        RestartWindow.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exit()
    {
        Application.Quit();
    }
}
