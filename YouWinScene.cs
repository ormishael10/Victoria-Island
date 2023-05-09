using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BackToHomeScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
