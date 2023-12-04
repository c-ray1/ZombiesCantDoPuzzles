using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public string keyType;

    void OnTriggerEnter(Collider other)
    {

        var keychain = other.GetComponent<Keychain>();

        if (keychain != null && keychain.HaveKey(keyType))
        {
            keychain.UseKey(keyType);
            Destroy(gameObject);

        }
    }
}