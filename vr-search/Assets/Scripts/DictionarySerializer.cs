using System;
using System.Collections.Generic;
using UnityEngine;

public class DictionarySerializer : MonoBehaviour
{
    [SerializeField] string thisObjectName;
    [SerializeField] NewDict newDict;
    public Dictionary<Texture, string> iconsWithNames;
    private void Awake()
    {
        iconsWithNames = newDict.ToDictionary();

    }
    public KeyValuePair<Texture, string> AccessByIndex(int index)
    {
        var list = new List<KeyValuePair<Texture, string>>(iconsWithNames);

        if (index >= 0 && index < list.Count)
        {
            var item = list[index];
            return item;
        }
        else
        {
            return list[0];
        }
    }
}
[Serializable]
public class NewDict
{
    [SerializeField] NewDictItem[] thisDictItems;
    public Dictionary<Texture, string> ToDictionary()
    {
        Dictionary<Texture, string> newDict = new Dictionary<Texture, string>();
        foreach (var item in thisDictItems)
        {
            newDict.Add(item.icon, item.iconName);
        }
        return newDict;

    }
}

[Serializable]

public class NewDictItem
{
    [SerializeField] public Texture icon;

    [SerializeField] public string iconName;

}
