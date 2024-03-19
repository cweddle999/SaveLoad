using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class ObjectRefernce : MonoBehaviour
{
    public static ObjectRefernce instance;

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
    public void Register(string key, Transform value)
    {
        if(_objectDictionary.ContainsKey(key) == true)
        {
            return _objectDictonary[key] = value;
        }
        else
        {
            _objectDictionary.Add(key, value);
        }
    }

    public Transform ReturnObject(string key)
    {
        if(_objectDirtionary.ContainsKey(key) == true)
        {
            return _objectDictionary[key];
        }

        return null;
    }
}
