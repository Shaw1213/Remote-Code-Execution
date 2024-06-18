using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public Text wordOutput = null;

    private string remaingwords = string.Empty;
    private string currentWord = string.Empty;

    private void Start()
    {
        setCurrentWord();
    }

    private void setCurrentWord()
    {
        currentWord = "apple";
        setRemaingWords(currentWord);
    }

    private void setRemaingWords(string newString)
    {
        remaingwords = newString;
        wordOutput.text = remaingwords;
    }
    private void CheckImput()
    {
        if(Input.anyKeyDown)
        {
            String keyPressed = Input.inputString;
            
            if(keyPressed.Length == 1)
            {
                EntterLetter(keyPressed);
            }
        }
    }

    private void EntterLetter (string typedLetter)
    {
        if (IsCurrentLetter(typedLetter))
        {
            RemoveLetter();

            if(IswordComplete())
            {
                setCurrentWord();
            }
        }
    }

    private bool IsCurrentLetter(string letter)
    {
        return remaingwords.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        String newString = remaingwords.Remove(0, 1);
        setRemaingWords(newString);
    }

    private bool IswordComplete()
    {
        return remaingwords.Length == 0;

    }

    private void Update()
    {
        CheckImput();
    }


}
