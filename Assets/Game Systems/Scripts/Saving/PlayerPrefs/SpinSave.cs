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

    private void Start()
    {
        if(PlayerPrefs.HasKey("Test Float4")) // Can be any of the values. If changes have been made to code between saves, the REGEDIT file may need to be deleted to set this, OR last string / value added needs to be set here
        {
            transform.rotation = new Quaternion(PlayerPrefs.GetFloat("Test Float1"), PlayerPrefs.GetFloat("Test Float2"),PlayerPrefs.GetFloat("Test Float3"), PlayerPrefs.GetFloat("Test Float4"));
        }
    }

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
            
            PlayerPrefs.SetFloat("Test Float1", transform.rotation.x);
            PlayerPrefs.SetFloat("Test Float2", transform.rotation.y);
            PlayerPrefs.SetFloat("Test Float3", transform.rotation.z);
            PlayerPrefs.SetFloat("Test Float4", transform.rotation.w); // w value is always required for a Quaternian

            PlayerPrefs.Save();
            //Writes all modified preferences to disk


            //By default Unity writes preferences to disk during OnApplicationQuit(). In cases when the game crashes or otherwise prematuraly exits,
            //you might want to write the PlayerPrefs at sensible 'checkpoints' in your game. This function will write to disk potentially causing a
            //small hiccup, therefore it is not recommended to call during actual gameplay.


            //isSpinning = (PlayerPrefs.GetInt("Spin") != 0);
            //Set = Write = Save
            //Sets the value of the preference identified by key
            //PlayerPrefs.SetString("Test String", stringToSaveAndLoad); Commented out due to compiler error for now.
            //isSpinning = bool.Parse(PlayerPrefs.GetString("Test Bool"));
            //PlayerPrefs.SetString("Test Bool", isSpinning.ToString());
            //PlayerPrefs.SetInt("Test Float", 1);

        }
    }

}
