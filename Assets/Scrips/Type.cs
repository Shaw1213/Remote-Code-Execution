using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Type : MonoBehaviour
{
    public Text wordOutput = null;
    public bool isTyping = false;

    public float typingGameInterval = 10f; // Interval in seconds
    private float timer = 0f;

    private string remainingWords = string.Empty;
    private string currentWord = string.Empty;

    // Update the wordBank list with the correct letters
    private List<string> wordBank = new List<string> { "y", "u", "i", "o", "p", "h", "j", "k", "l", "n", "m" };

    private void Start()
    {
        wordOutput.gameObject.SetActive(false); // Initially hide the text
    }

    private void SetCurrentWord()
    {
        if (wordBank.Count > 0)
        {
            int randomIndex = Random.Range(0, wordBank.Count);
            currentWord = wordBank[randomIndex];
            SetRemainingWords(currentWord);
        }
        else
        {
            Debug.LogError("Word bank is empty. Please add words to the word bank.");
        }
    }

    private void SetRemainingWords(string newString)
    {
        remainingWords = newString;
        wordOutput.text = remainingWords;
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;

            if (keyPressed.Length == 1)
            {
                EnterLetter(keyPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCurrentLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                isTyping = false; // Deactivate typing game
                wordOutput.gameObject.SetActive(false); // Hide the text
                timer = 0f; // Reset timer
            }
        }
    }

    private bool IsCurrentLetter(string letter)
    {
        return remainingWords.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWords.Remove(0, 1);
        SetRemainingWords(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWords.Length == 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (!isTyping && timer >= typingGameInterval)
        {
            isTyping = true; // Activate typing game
            SetCurrentWord();
            wordOutput.gameObject.SetActive(true); // Show the text
        }

        if (isTyping)
        {
            CheckInput();
        }
    }
}
