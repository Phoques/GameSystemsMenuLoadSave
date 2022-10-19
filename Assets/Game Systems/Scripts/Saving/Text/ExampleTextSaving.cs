using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
// using UnityEditor will not work with builds but is good for editing things as a dev, so you may need to comment code out that uses ythe editor before building.
public class ExampleTextSaving : MonoBehaviour
{

    // Input values for saving
    public string[] whatWeAreSaving;
    
    // Display what we have loaded after we split a string
    public string[] showWhatWeAreSplitting;
    
    //Put some of the values into an array
    public string[] showStringsLoaded;
    
    //Some of the values are into an INT
    public int showIntLoaded;

    //Path for saving and loading
    public string path = "Assets/Game Systems/Resources/Save/TextSaveFile.txt";

    void Write()
    {
        // True adds data to the save
        // False replaces data entirely

        StreamWriter writer = new StreamWriter(path, false);

        // For everything we are saving
        for (int i = 0; i < whatWeAreSaving.Length; i++)
        {
            // If its not the last piece of data
            if (i < whatWeAreSaving.Length - 1)
            {
                // when saving add a marker | to seperate the data values
                writer.Write(whatWeAreSaving[i] + '|');
            }
            else // if we are the last piece of data
            {
                // We dont need a marker | on the end as we are the end so just save the data
                writer.Write(whatWeAreSaving[i]);
            }
        }

        //This lets us stop the data stream aka stop the process of saving so shiz dont break
        writer.Close();

        //this next part is the only thing tied to Unity Editor SO if you neeed to make a build of the game this NEEDS to be commented out.
        AssetDatabase.ImportAsset(path);

        // What it does is allows if we have the save file selected and displaying in the inspetor... the inspector updates when we save (Otherwise it does not show)
        //else it doesnt look like anything happens.


    }

    void Read()
    {
        StreamReader reader = new StreamReader(path);

        //Temporarily store the loaded info
        string tempRead = reader.ReadLine();

        // Splitting up the line at the marker | and putting each value into our array
        showWhatWeAreSplitting = tempRead.Split('|');

        // Seperate our last value is the goal of the following

        //Set our string array to the size of our splitted data minus the last piece of data.. as that will be an int
        showStringsLoaded = new string[showWhatWeAreSplitting.Length - 1];

        // Assign the string value to our string array
        for (int i  = 0; i < showStringsLoaded.Length; i++)
        {
            showStringsLoaded[i] = showWhatWeAreSplitting[i];
        }
        // Assign and convert our int value
        showIntLoaded = int.Parse(showWhatWeAreSplitting[showWhatWeAreSplitting.Length - 1]);

        //Stop the load shiz
        reader.Close();

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Write();
        }

        // Saving
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Read();
        }
    }

}
