using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _audioManager; // Static class means there is only one, this is used in conjucntion with a singleton pattern. A STATIC Class means it is a single class.
    // 
    public static AudioManager AudioManagerInstance
    {

        get => _audioManager; // the => means get return, getting the information from the Audiomanager

        private set
        {
            if (_audioManager == null)
            {
                _audioManager = value;
            }
            else if (_audioManager != value)
            {
                Debug.Log($"{nameof(AudioManager)} instance already exists, destroy the imposter! THERE CAN BE ONLY ONE!!!");
                Destroy(value.gameObject);
            }
        }

    }

    private void Awake()
    {
        AudioManagerInstance = this;
        DontDestroyOnLoad(this.gameObject); // DontDestroyOnLoad means it wont be destroyed between scenes. (I think it has to be a static class tho)
    }





}
