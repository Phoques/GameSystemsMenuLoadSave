using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpinSave : MonoBehaviour
{
    //public string isSpinning;
    public bool isSpinning;

    // https://gamedevtraum.com/en/game-and-app-development-with-unity/unity-tutorials-and-solutions/how-to-save-and-load-a-bool-variable-with-playerprefs-in-unity/


    //isBool = bool.Parse(PlayerPrefs.GetString("Test Bool", "false"))
    //PlayerPrefs.SetString("Test Bool", isBool.ToString());



    private void Update()
    {


        //When User Presses button 7
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            //Toggle is Spin
            //if it is true change to false else if is false change to true
            //this is because bools have only 2 state
            //it is one or the other
            isSpinning = !isSpinning;            
        }
        //if/while we are true
        if (isSpinning)
        {
            //spin boy spin
            transform.Rotate(1, 2, 2);
        }
    if (Input.GetKeyDown(KeyCode.Alpha2)) // Alpha1 is the 1 number on the keyboard, opposed to the numpad 1 same for all Alpha#
        {
            PlayerPrefs.SetInt("Spin", (isSpinning? 1 : 0));
            isSpinning = (PlayerPrefs.GetInt("Spin") != 0);
            PlayerPrefs.Save();
            //Set = Write = Save
            //Sets the value of the preference identified by key
            //PlayerPrefs.SetString("Test String", stringToSaveAndLoad); Commented out due to compiler error for now.
            //isSpinning = bool.Parse(PlayerPrefs.GetString("Test Bool"));
            //PlayerPrefs.SetString("Test Bool", isSpinning.ToString());
            //PlayerPrefs.SetInt("Test Float", 1);
            //PlayerPrefs.SetFloat("Test Float", 1f);
            //Writes all modified preferences to disk
            

            //By default Unity writes preferences to disk during OnApplicationQuit(). In cases when the game crashes or otherwise prematuraly exits,
            //you might want to write the PlayerPrefs at sensible 'checkpoints' in your game. This function will write to disk potentially causing a
            //small hiccup, therefore it is not recommended to call during actual gameplay.

        }
    }

}
