using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SCREEN { MAIN, VR, APPS, GAMES, EVENTS, VIEW }
public class MainMenuSystem : MonoBehaviour
{

    [Header("REFERENCE")]
    public Canvas[] canvas;
    public ViewSystem viewSystem;

    [Header("QUERY")]
    public SCREEN currentScreen;

    // Start is called before the first frame update
    public void Start()
    {
        for (int i = 0; i < canvas.Length; i++){
            canvas[i].enabled = false;
        }

        currentScreen = SCREEN.MAIN;
        changeScreen(0);
    }


    public void changeScreen(int _screen)
    {
        canvas[(int)currentScreen].enabled = false;
        currentScreen = (SCREEN)_screen;
        canvas[(int)currentScreen].enabled = true;
    }

   
    public void goView(Project _project)
    {
        canvas[(int)currentScreen].enabled = false;
        canvas[5].enabled = true;
        viewSystem.newProject(_project);
    }


    public void returnFromView()
    {
        canvas[5].enabled = false;
        changeScreen((int)currentScreen);
    }


}