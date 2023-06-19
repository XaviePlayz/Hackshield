using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class buttonCheck : MonoBehaviour
{
    public CharacterDisplay check;
    public GameObject wrongAnswer;
    public GameObject rightAnswer;
    public GameObject phoneScreen;
    //public TMP_Text buttonText;

    public string buttonTag = "Button";

    private bool isHidden = false;
    // Start is called before the first frame update
    void Start()
    {
        wrongAnswer.SetActive(false);
        rightAnswer.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(wrongAnswer.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                wrongAnswer.SetActive(false);
                rightAnswer.SetActive(false);
                phoneScreen.SetActive(true);
            }
        }
        else
            if (rightAnswer.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                wrongAnswer.SetActive(false);
                rightAnswer.SetActive(false);
                phoneScreen.SetActive(true);
            }
        }
    }

    public void buttonClick()
    {
        if (check.characterData.accept = false)
        {
            wrongAnswer.SetActive(true);
            phoneScreen.SetActive(false);
        }
        else
        {
            rightAnswer.SetActive(true);
            phoneScreen.SetActive(false);
        }

    }

    public void noClick()
    {
        if (check.characterData.accept = true)
        {
            wrongAnswer.SetActive(true);
            phoneScreen.SetActive(false);
        }
        else
        {
            rightAnswer.SetActive(true);
            phoneScreen.SetActive(false);
        }
    }
}
