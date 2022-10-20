using System;
[Serializable]
//This is the small percentage where we do not inheret from monobehaviour, because we do not need it to be able ot be attached to an object. We can call this in other ways.
public class PlayerData
{
    // Data from the player in the game we want to save

    public string characterName;
    //postion (Which would be a struct of 3 floats) 
    //public float pX, pY, pZ
    [Serializable]

    public struct Position
    {
        public float x, y, z;
    }
    public Position position;

    //rotation
    [Serializable]
    public struct Rotation
    {
        public float x, y, z, w;
    }
    public Rotation rotation;

    // Health - Stats
    public PlayerData(PlayerHandler player)
    {
        characterName = player.name;
        
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        position.z = player.transform.position.z;

        rotation.x = player.transform.rotation.x;
        rotation.y = player.transform.rotation.y;
        rotation.z = player.transform.rotation.z;
        rotation.w = player.transform.rotation.w;
    }



    //Inventory (Though not yet cause we havent done it)
}
