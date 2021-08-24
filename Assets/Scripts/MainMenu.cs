using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("Play Button has been pressed");
    }

    public void Options(){
        print("Options Button has been pressed");

    }

    public void Quit(){
        print("Quit Button has been pressed");
        Application.Quit();
    }

}
