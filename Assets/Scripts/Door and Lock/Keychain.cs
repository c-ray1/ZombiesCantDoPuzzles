using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keychain: MonoBehaviour
{
    List<string> m_KeyTypeOwned = new List<string>();

    [Header("Set in Inspector")]
    public Player player;

    public void GrabbedKey(string keyType)
    {
        //print(keyType);
        m_KeyTypeOwned.Add(keyType);
        player.Keys.Add(keyType);
        Debug.Log("KeyType Added: " + m_KeyTypeOwned.Contains(keyType));
    }

    public bool HaveKey(string keyType)
    {
        return m_KeyTypeOwned.Contains(keyType);
    }

    public void UseKey(string keyType)
    {
        m_KeyTypeOwned.Remove(keyType);
        player.Keys.Remove(keyType);
    }
}
