using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class cManager : MonoBehaviour
{
    public CharacterDisplay currentChar;
    private int currentIndex = 0;
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
        // Load encounters in the desired order based on    encounterNumber
        CharacterData[] loadedEncounters = Resources.LoadAll<CharacterData>("Encounters");
        Array.Sort(loadedEncounters, (a, b) => a.encounterNumber.CompareTo(b.encounterNumber));

        // Merge the loaded encounters with the existing encounterList
        List<CharacterData> mergedList = new List<CharacterData>(loadedEncounters); // Preserve existing encounters
        mergedList.AddRange(loadedEncounters); // Add loaded encounters
        currentChar.characterData = mergedList[SceneManagerScript.currentCount];
        
        Debug.Log(mergedList[0]); 

    }
}

