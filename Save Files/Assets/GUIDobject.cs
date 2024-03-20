using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GUIDobject : MonoBehaviour
{
    [SerializeField] private string _GUID;

    private void OnEnable()
    {
        if (_GUID == string.Empty)
        {
            GenerateGUID();
        }

    }
    private void Start()
    {
       // this loop allows you to bypass the [ExecuteAlways] function at the start of the script
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
