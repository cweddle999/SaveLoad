using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GUIDobject : MonoBehaviour
{
    [SerializeField] private string _GUID;

    private void OnEnable()
    {
        if(_GUID == string.Empty)
        {
            GenerateGUID();
        }

    }

    public void GenerateGUID()
    {
        _GUID = System.Guid.NewGuid().ToString();
    }
}
