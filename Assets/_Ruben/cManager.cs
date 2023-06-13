using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class cManager : MonoBehaviour
{
    public CharacterDisplay currentChar;
    private int currentIndex = 0;
    private List<CharacterData> mergedList;
    // Start is called before the first frame update
    void Start()
    {
        LoadEncountersInOrder();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadEncountersInOrder()
    {
        // Load encounters in the desired order based on encounterNumber
        CharacterData[] loadedEncounters = Resources.LoadAll<CharacterData>("Encounters");
        Array.Sort(loadedEncounters, (a, b) => a.encounterNumber.CompareTo(b.encounterNumber));

        // Merge the loaded encounters with the existing encounterList
        mergedList = new List<CharacterData>(loadedEncounters); // Preserve existing encounters
        mergedList.AddRange(loadedEncounters); // Add loaded encounters

        DisplayNextCharacter();
    }

    public void DisplayNextCharacter()
    {
            
        if (currentIndex < mergedList.Count)
        {
            currentChar.characterData = mergedList[currentIndex];
            Debug.Log(mergedList[currentIndex]);
            currentIndex++;
        }
        else
        {
            Debug.Log("No more characters to display.");
        }
    }
}
