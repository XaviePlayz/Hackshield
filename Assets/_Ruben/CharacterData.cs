using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    public int age;
    public string memberSinceDate;
    public string[] predefinedMessages;
}
