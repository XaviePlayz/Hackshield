using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public int age;
    public string memberSinceDate;
    public string predefinedMessages;
    public string friend1;
    public string friend2;
    public string nameCharacter;
    public Sprite characterImage;
    public bool accept;
    public int encounterNumber;
    public List<CharacterData> encounterList = new List<CharacterData>();
    public void LoadEncountersInOrder()
    {
        // Load encounters in the desired order based on encounterNumber
        CharacterData[] loadedEncounters = Resources.LoadAll<CharacterData>("Encounters");
        Array.Sort(loadedEncounters, (a, b) => a.encounterNumber.CompareTo(b.encounterNumber));

        // Merge the loaded encounters with the existing encounterList
        List<CharacterData> mergedList = new List<CharacterData>(encounterList); // Preserve existing encounters
        mergedList.AddRange(loadedEncounters); // Add loaded encounters

        // Assign the merged list back to the encounterList field
        encounterList = mergedList;
    }

}
