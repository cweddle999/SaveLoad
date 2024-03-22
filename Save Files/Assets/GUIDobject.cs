using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class gives a GUID (a unique id)
/// @ start of game, registers this object and its GUID.
/// </summary>
[ExecuteAlways]
public class GUIDobject : MonoBehaviour
{
    [SerializeField] private string _GUID;
    public string getGUID { get { return _GUID; } }
   
    // Method OnEnable checks if a GUID exists, if not it will make one.
    private void OnEnable()
    {
        if (_GUID == string.Empty)
        {
            GenerateGUID();
        }

    }
    private void Start()
    {
       // loop allows you to bypass the [ExecuteAlways] function at the start of the script
       // once the game is actually fired then it will register GUID.
        if(Application.isPlaying == false)
        {
            return;
        }
        
        ObjectRefernce.instance?.Register(_GUID, transform);
    }

    public void GenerateGUID()
    {
        _GUID = System.Guid.NewGuid().ToString();
    }
}
