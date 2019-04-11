using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public GameObject winGame;
    public GameObject gameOver;

    public void WinGame()
    {
        winGame.SetActive(true);
        Invoke("Restart", 3f);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Debug.Log("GAME OVER");
            if (winGame.activeSelf == false)
            {
                gameOver.SetActive(true);
                Invoke("Restart", 3f);
            }   
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
