using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    public Text headerText;
    public InputField guessInputField;
    public Button submitButton;
    public Button resetButton;

    private int randomNumber;
    private int attemptsRemaining;

    void Start()
    {
        GameSetup();
        submitButton.onClick.AddListener(SubmitGuess);
        resetButton.onClick.AddListener(GameSetup);
    }

    void GameSetup()
    {
        randomNumber = Random.Range(1, 11); // Random number between 1 and 11
        attemptsRemaining = 3; // Reset attempts
        headerText.text = "Guess a number between 1 and 10! Attempts remaining: " + attemptsRemaining;
        guessInputField.text = ""; // Clear input field
        guessInputField.interactable = true; // Enable input field
        submitButton.interactable = true; // Enable submit button
    }

    void SubmitGuess()
    {
        if (string.IsNullOrEmpty(guessInputField.text))
        {
            headerText.text = "Please enter a number!";
            return;
        }

        if (!int.TryParse(guessInputField.text, out int playerGuess))
        {
            headerText.text = "Please enter a valid number!";
            return;
        }

        if (playerGuess < 1 || playerGuess > 10)
        {
            headerText.text = "Number must be between 1 and 10!";
            return;
        }

        if (playerGuess == randomNumber)
        {
            headerText.text = "Congratulations! You guessed the number!";
            guessInputField.interactable = false; // Disable input field
            submitButton.interactable = false; // Disable submit button
        }
        else
        {
            attemptsRemaining--;
            if (attemptsRemaining > 0)
            {
                headerText.text = "Wrong guess! Attempts remaining: " + attemptsRemaining;
            }
            else
            {
                headerText.text = "Game Over! The number was: " + randomNumber;
                guessInputField.interactable = false; // Disable input field
                submitButton.interactable = false; // Disable submit button
            }
        }

        guessInputField.text = ""; // Clear input field after submission
    }
}