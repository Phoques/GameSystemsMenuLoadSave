using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // this is required to convert binary at runtime.
using UnityEngine;

public static class PlayerBinary
{
    public static void SaveData(PlayerHandler player)
    {
        //reference to our binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        //Location to save(aka our path)
        string path = Application.persistentDataPath + "/" + "Flower_texture" + ".jpeg";

        //create a file at that file path / potentially replace the file
        FileStream writeDataStream = new FileStream(path, FileMode.Create);

        //what data to write to the file
        PlayerData data = new PlayerData(player);

        //write that data from the serialized byte stream (aka the unity data that we have converted to bytes so we can save it to the file... Writing is saving)
        formatter.Serialize(writeDataStream, data);

        //and we are done with the action so close the byte stream and finish writing.
        writeDataStream.Close();
    }
    //This is asking for a return type, as void does not return anything, in this circumstance PlayerData is asking to be returned.
    public static PlayerData LoadData(PlayerHandler player)
    {
        //location to save (aka our path)
        string path = Application.persistentDataPath + "/" + "Flower_Texture" + ".jpeg";
        
        //if we have a file at that path
        if (File.Exists(path))
        {
            //Reference to our Binary formattter
            BinaryFormatter formatter = new BinaryFormatter();
            
            //Open the file at that file path
            FileStream readDataStream = new FileStream(path, FileMode.Open);

            // read that data from the file and deserialize the bytes in the stream (aka turn the unity data that we have converted into bytes during saving, back into c# data for
            //unity to use ... reading is loading.
            PlayerData data = formatter.Deserialize(readDataStream) as PlayerData;

            //and we are done with the action so close the byte stream and finish reading
            readDataStream.Close();

            // send the usable data to the PlayerData Script
            return data;

        }


        return null;
    }

}
