using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public Animator[] animatorsToPlay;
    public void Start()
    {
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        foreach (Animator animator in animatorsToPlay)
        {
            animator.SetBool("isPlay", true);
        }
        
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
