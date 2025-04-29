using System;
using System.Collections.Generic;
using UnityEngine;

public class DictionarySerializer : MonoBehaviour
{
    [SerializeField] string thisObjectName;
    [SerializeField] CryptoDictionary cryptoDictionary;
    public Dictionary<Texture, string> iconsWithNamesDictionary;
    private void Awake()
    {
        iconsWithNamesDictionary = cryptoDictionary.ToDictionary();

    }
    public KeyValuePair<Texture, string> AccessByIndex(int index)
    {
        var listOfCrypto = new List<KeyValuePair<Texture, string>>(iconsWithNamesDictionary);

        if (index >= 0 && index < listOfCrypto.Count)
        {
            var cryptoItem = listOfCrypto[index];
            return cryptoItem;
        }
        else
        {
            return listOfCrypto[0];
        }
    }
}
[Serializable]
public class CryptoDictionary
{
    [SerializeField] CryptoItem[] cryptoItems;
    public Dictionary<Texture, string> ToDictionary()
    {
        Dictionary<Texture, string> newDict = new Dictionary<Texture, string>();
        foreach (var cryptoItem in cryptoItems)
        {
            newDict.Add(cryptoItem.icon, cryptoItem.iconName);
        }
        return newDict;

    }
}

[Serializable]

public class CryptoItem
{
    [SerializeField] public Texture icon;

    [SerializeField] public string iconName;

}
