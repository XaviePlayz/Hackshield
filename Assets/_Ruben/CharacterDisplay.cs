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
    public TMP_Text jaOptie;
    public TMP_Text neeOptie;

    private void Start()
    {
        // Load the character data
        LoadCharacterData();

       
    }
    private void LoadCharacterData()
    {
        // Load the character image 
        characterImage.sprite = characterData.characterImage;
        extraPic.sprite = characterData.extraImage;

        // Load the text data from the CharacterData scriptable object
        nameText.text = characterData.nameCharacter;
        extraName.text = characterData.extraNaam;
        ageText.text = "Leeftijd: " + characterData.age.ToString();
        memberSinceText.text = "Lid sinds: " + characterData.memberSinceDate;
        friendone.text = characterData.friend1.ToString();
        friendtwo.text = characterData.friend2.ToString();
        jaOptie.text = characterData.jaZin.ToString();
        neeOptie.text = characterData.neeZin.ToString();

       

        messagePhone.text = characterData.predefinedMessages.ToString();
    }
}
