using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    public CharacterData characterData;
    public Image characterImage;
    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text memberSinceText;
    public TMP_Text friendsText;
    public TMP_Text messagePhone;
    public TMP_Text friendone;
    public TMP_Text friendtwo;
    public Image extraPic;
    public TMP_Text extraName;

    private void Start()
    {
        // Load the character data
        LoadCharacterData();

        // Display the character data
        DisplayCharacterData();
    }

    private void LoadCharacterData()
    {
        // Load the character image (assuming it's stored in the CharacterData scriptable object)
        characterImage.sprite = characterData.characterImage;
        extraPic.sprite = characterData.extraImage;

        // Load the text data from the CharacterData scriptable object
        nameText.text = characterData.nameCharacter;
        extraName.text = characterData.extraNaam;
        ageText.text = "Leeftijd: " + characterData.age.ToString();
        memberSinceText.text = "Lid sinds: " + characterData.memberSinceDate;
        friendone.text = characterData.friend1.ToString();
        friendtwo.text = characterData.friend2.ToString();

       

        messagePhone.text = characterData.predefinedMessages.ToString();
    }

    private void DisplayCharacterData()
    {
        // Display the character data on the canvas
        // (Assuming you have a canvas object in your scene with appropriate child elements)
        // You can access the canvas UI elements and set their text/image as required.
        // For example:
        // nameText.text = characterData.nameCharacter;
        // ageText.text = "Age: " + characterData.age.ToString();
        // memberSinceText.text = "Member Since: " + characterData.memberSinceDate;
        // ...
    }
}
