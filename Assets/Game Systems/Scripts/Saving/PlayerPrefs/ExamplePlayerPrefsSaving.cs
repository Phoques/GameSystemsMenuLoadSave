using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerPrefsSaving : MonoBehaviour
{
    /*
    Pro vs Con of PlayePrefs:
    
    Pros
        -Prebuilt   
        - Already has all the functions and functionality
        - easy to use
        - Saves a Key (name / reference) and value (data) similar to a dictionary. (Dictionary as in code dictionary)
        - Easy to Edit for developers    

    Cons
        - Not Flexible (Only saves float, int, string) <- This is important, you need to convert things
        - Easy to Edit - Players can easily mess with the file
        - WebPlayer has a PlayerPrefs size limit, which is 1MB.
    
    What is it good for?
        - User/Options/Settings - Not game progress or Player things (Progress / money / items) This is best used for things like resolution options etc (think changing an .ini file)
    so they can change things outside of the game if need be.


    */


    public string stringToSaveAndLoad;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Test String"))
        {
            //if there is data called Test String
            Debug.Log("Data was found");
        }
        else
        {
            //There is no data called Test String in thes Saves
            Debug.Log("No Save data");
        }
    }

    void Start()
    {
        //Returns the value corresponding to key in the preferecnce file if it exists. This is being setup as the default.
        stringToSaveAndLoad = PlayerPrefs.GetString("Test String", "Cheese");
    }

    // Update is called once per frame
    void Update()
    { 
        // Saving
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Alpha1 is the 1 number on the keyboard, opposed to the numpad 1 same for all Alpha#
        {
            //Set = Write = Save
            //Sets the value of the preference identified by key
            PlayerPrefs.SetString("Test String", stringToSaveAndLoad);

            PlayerPrefs.SetInt("Test Float", 1);
            PlayerPrefs.SetFloat("Test Float", 1f);
            //Writes all modified preferences to disk
            PlayerPrefs.Save();

            //By default Unity writes preferences to disk during OnApplicationQuit(). In cases when the game crashes or otherwise prematuraly exits,
            //you might want to write the PlayerPrefs at sensible 'checkpoints' in your game. This function will write to disk potentially causing a
            //small hiccup, therefore it is not recommended to call during actual gameplay.

        }
        //Delete String
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Removes key and its corresponding value from the preferences
            PlayerPrefs.DeleteKey("Test String");
        }

        //Delete all
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Removes all keys and values from the references. Use with caution.
            PlayerPrefs.DeleteAll();

        }

    }




}
