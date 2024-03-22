using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

/// <summary>
/// Stores all game state information
/// Each GUID object is responseable for storing and loading its own data
/// Game data is just a container for those bits of information.
/// </summary>
[System.Serializable]
public class GameData
{
   // Stores all the GUID objects in the game
   // there are many types of guid objects but they will all be stored as their based type
   // there for the inherited types will always be GUID object tokens (despite having more features).
    private List<GUIDobjecttoken> _guidsInGame = new List<GUIDobjecttoken>();
    public GameData()
    {
        // Get the object registery and loop through all the contained GUIDs and then store them as GUID tokens
        // based on their specific needs.
        foreach (KeyValuePair<string, Transform> item in ObjectRefernce.instance.GetObjectDictionary)
        {
            // find out what kind of GUID object that we are currently looking at, then make a token for the corresponding GUID
            // add that token to the GUID list to be saved.
            CharacterGUID guid = ObjectRefernce.instance.ReturnObject(item.Key).GetComponent<CharacterGUID>();
            if (guid != null)
            {
                _guidsInGame.Add(new CharacterGUIDToken(guid));
            }
            DodadGUID dodad = ObjectRefernce.instance.ReturnObject(item.Key).GetComponent<DodadGUID>();
            if (dodad != null)
            {
                _guidsInGame.Add(new DodadGUIDToken(dodad));
            }
        }

    }
    // All guid tokens are responseable for storing and loading their own data
    // simply loop through all the guid tokens and request that they load their data as they require.
    public void LoadGUIDData()
    {
        for (int i = 0; i < _guidsInGame.Count; i++)
        {
            _guidsInGame[i].LoadGUIDData();
        }
    }
}

/// <summary>
/// the base type of GUID token
/// Other tokens will store unique information
/// this base version can never be used outside of being inherited
/// as the base type all guid objects will use it to store their information
/// </summary>
[System.Serializable]
public abstract class GUIDobjecttoken
{
    protected string _guid;
    protected VectorToken _position;
    protected VectorToken _rotation;

    // A fully complete method but is virtual so that more "can" be added if needed
    // some GUID types such as characters need to load more information such as Health and Mana 
    // which will override the method but can still call the base to handle the generic information.
    public virtual void LoadGUIDData()
    {
        Transform go = ObjectRefernce.instance.ReturnObject(_guid);
        go.position = _position.GetVector;
        go.rotation = Quaternion.Euler(_rotation.GetVector);
    }
}
/// <summary>
/// Stores the base GUID object information
/// but also stores character specific information like health and mana.
/// </summary>
[System.Serializable]
public class CharacterGUIDToken : GUIDobjecttoken
{
    private int _heatlh;
    private int _mana;
   
    public CharacterGUIDToken(CharacterGUID go) 
    {
        _guid = go.getGUID;
        _position = new VectorToken(go.transform.position);
        _rotation = new VectorToken(go.transform.rotation.eulerAngles);
        _heatlh = go.Health;
        _mana = go.Mana;
    }
    // override allows the character to change the base method to load the base information
    // but also allows the character specific information such as Health and mana to be loaded.
    public override void LoadGUIDData()
    {
        base.LoadGUIDData();
        CharacterGUID go = ObjectRefernce.instance.ReturnObject( _guid).GetComponent<CharacterGUID>();
        go.Health = _heatlh;
        go.Mana = _mana;
    }
}
/// <summary>
/// Stores base information for objects like Barrels, Boxs, etc 
/// this token only exists because the base is abstract and there for can not be created.
/// </summary>
[System.Serializable]
public class DodadGUIDToken : GUIDobjecttoken
{
    public DodadGUIDToken(DodadGUID go)
    {
        _guid = go.getGUID;
        _position = new VectorToken(go.transform.position);
        _rotation = new VectorToken(go.transform.rotation.eulerAngles);
    }
}
/// <summary>
/// Since Vectors can not be save and loaded
/// this exists to store the floats of the vector in a saveable and loadable way.
/// </summary>
[System.Serializable]
public class VectorToken
{
    private float _x;
    private float _y;
    private float _z;

    public Vector3 GetVector { get { return new Vector3(_x, _y, _z); } }

    public VectorToken(Vector3 v)
    {
        _x = v.x;
        _y = v.y;
        _z = v.z;
    }
}