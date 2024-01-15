using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public string nextScene;
    public void playGame()
    {
        SceneManager.LoadScene(nextScene);
    }

     public void storyGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }


    List<int> widths = new List<int>() {800, 1280, 1366, 1920};
    List<int> heights = new List<int>() {600, 720, 768, 1080};

    public void SetScreenSize (int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void setFullscreen (bool _fullScreen)
    {
        Screen.fullScreen = _fullScreen;
    }
}
