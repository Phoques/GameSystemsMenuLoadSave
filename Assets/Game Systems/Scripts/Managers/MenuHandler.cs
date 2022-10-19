using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    //Singular reference
   // public GameObject anyKey;
  //  public GameObject menu;
 //   public GameObject options;
    //Array Reference
    public GameObject[] panels;
    //^USE EITHER//
    public MenuStates menuState;
    private void Start()
    {
        ChangePanel(0);
    }
    public void Update()
    {
        if (menuState == MenuStates.AnyKey)
        {
            if (Input.anyKey)
            {
                ChangePanel(1);
            }
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
        // Below is Developer code that only works when in the editor. This allows us to 'quit' play mode when the QUIT button is pressed. You can ruin debugging keys etc in here because it ONLY works in editor.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    
    public void ChangePanel(int value)
    {
        menuState = (MenuStates)value;

        switch (menuState)
        {
            case MenuStates.AnyKey:
                //Single example
           //     anyKey.SetActive(true);
         //       menu.SetActive(false);
         //       options.SetActive(false);
                //Array Example
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[0].SetActive(true);

                break;
            case MenuStates.MainMenu:
                //Single example
            //    anyKey.SetActive(false);
           //     menu.SetActive(true);
           //     options.SetActive(false);
                //Array Example
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[1].SetActive(true);
                break;
            case MenuStates.Options:
                //Single example
             //   anyKey.SetActive(true);
             //   menu.SetActive(false);
             //   options.SetActive(false);
                //Array Example
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[2].SetActive(true);
                break;
            default:
                //Single example
             //   anyKey.SetActive(false);
            //    menu.SetActive(false);
             //   options.SetActive(true);
                //Array Example
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[0].SetActive(true);
                menuState = MenuStates.AnyKey;
                break;
        }
    }
}
public enum MenuStates
{
    AnyKey,
    MainMenu,
    Options
}