using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public int age;
    public string memberSinceDate;
    public string predefinedMessages;
    public string[] friends;
    public string nameCharacter;
    public Sprite characterImage;
}
