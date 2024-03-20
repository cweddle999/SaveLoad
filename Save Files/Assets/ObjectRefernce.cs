using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class ObjectRefernce : MonoBehaviour
{
    public static ObjectRefernce instance;

    private Dictionary<string, Transform> _objectDictionary = new Dictionary<string, Transform>();

    public Dictionary<string, Transform> GetObjectDictionary { get { return _objectDictionary; } }

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
            _objectDictionary[key] = value;
        }
        else
        {
            _objectDictionary.Add(key, value);
        }
    }

    public Transform ReturnObject(string key)
    {
        if(_objectDictionary.ContainsKey(key) == true)
        {
            return _objectDictionary[key];
        }

        return null;
    }
}
