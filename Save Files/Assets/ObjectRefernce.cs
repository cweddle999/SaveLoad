using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

/// <summary>
/// Stores all GUID objects in a dictionary
/// So that all the objects and quick and easy to find
/// When the game saves/loads, we have access to those objects to get or set their values.
/// </summary>
public class ObjectRefernce : MonoBehaviour
{
    // Public version of the only register that exists, all objects can reference this register through the instance.
    public static ObjectRefernce instance;
    // private verison of the dictionary that can not be edited by any other method, and that instance gets the information from.
    // uses keys to find values, in this case GUID object will have a unique ID that can be associated with X transform.
    private Dictionary<string, Transform> _objectDictionary = new Dictionary<string, Transform>();

    public Dictionary<string, Transform> GetObjectDictionary { get { return _objectDictionary; } }
    // method Awake checks if the instance is empty
    // if instance is empty it will fill the empty instance
    // if filled the new instance will be destroyed.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    /// <summary>
    /// Checks if the parsed in key already exists
    /// if so do not add a new version, just sets the value for that key.
    /// otherwise, add a new key value pair of the parsed in values.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Register(string key, Transform value)
    {
        if(_objectDictionary.ContainsKey(key) == true)
        {
            _objectDictionary[key] = value;
        }
        else
        {
            _objectDictionary.Add(key, value);
        }
    }
    /// <summary>
    /// checks if the object has a key
    /// if the object has a key, then return the transform value.
    /// otherwise return nothing.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Transform ReturnObject(string key)
    {
        if(_objectDictionary.ContainsKey(key) == true)
        {
            return _objectDictionary[key];
        }

        return null;
    }
}
