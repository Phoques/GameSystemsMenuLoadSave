using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static PlayerHandler player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
    }
    
    // If we are attching this function to a Ui button, it CANNOT be static. Static hides things from the inspector.
    public void Save()
    {
        PlayerBinary.SaveData(player);
    }

    public void Load()
    {
        // We have to set the character controller as false to begin with, as it is physics based and the controller doesnt like to be moved out of its control
        //So we make it false at the start, get the rest of the data and then make it true so it isnt 'teleporting' its just hey that was last known position.
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        PlayerData data = PlayerBinary.LoadData(player);
        player.name = data.characterName;
        player.transform.position = new Vector3(data.position.x, data.position.y, data.position.z);
        player.transform.rotation = new Quaternion(data.rotation.x, data.rotation.y, data.rotation.z, data.rotation.w);
        player.gameObject.GetComponent<CharacterController>().enabled = true;
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Load();
        }

    }

}
