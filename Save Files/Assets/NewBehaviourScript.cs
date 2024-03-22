using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class NewBehaviourScript
{
    /// <summary>
    /// SaveLoad creates a new binary file
    /// Opens the file stream to save the parsed in game data, into the newly made file.
    /// Then closes the stream to prevent crashing.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="gd"></param>
    public static void Save(string fileName, GameData gd)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + fileName + ".dat";
        FileStream fs = new FileStream(path, FileMode.Create);
        bf.Serialize(fs, gd);
        // always close files
        fs.Close();
        Debug.Log(path);
    }
    /// <summary>
    /// Looks for a file, if it exists, open the file
    /// Gather the relevant stored information, then returns what was found.
    /// If the file was not found, return null.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static GameData Load(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".dat";
        if(File.Exists(path) == true)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            GameData gd = bf.Deserialize(fs) as GameData;
            // ALWAYS CLOSE!
            fs.Close();
            return gd;
        }
        return null;
    }
}
