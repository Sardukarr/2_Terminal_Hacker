using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    int retries = 3;
    enum Screen { MainMenu, Password, Win };
    string[] Easy = {"books","aisle","password","font","borrow"};
    string[] Medium = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] Hard = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    int NumberOfStringEachLevel;
    Screen currentScreen;
    string CorrectPassword;
    // Start is called before the first frame update
    void Start()
    {
        currentScreen = Screen.MainMenu;
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello There");
        Terminal.WriteLine("What you want to do?");
        Terminal.WriteLine("1 - hack into local library");
        Terminal.WriteLine("2 - hack into local police");
        Terminal.WriteLine("3 - hack into NASA\n");
        Terminal.WriteLine("Enter :");
    }
    void OnUserInput(string input)
    {
        switch (currentScreen)
        {
            case Screen.MainMenu:
                RunMainMenu(input);
                break;
            case Screen.Password:
                CheckPassowrd(input);
                break;
            case Screen.Win:
                break;
        }
    }

    private void CheckPassowrd(string input)
    {
        if (input == CorrectPassword)
            Terminal.WriteLine("sucess, you are in.");
        else if (retries > 0)
        { 
            Terminal.WriteLine("wrong password, try again:");
            retries--;
        }
        else 
           Terminal.WriteLine("wrong password, calling security");
    }

    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
                level = 1;
                StartGame();
                break;
            case "2":
                level = 2;
                StartGame();
                break;
            case "3":
                level = 3;
                StartGame();
                break;
            case "menu":
            case "Menu":
            case "MENU":
                ShowMainMenu();
                break;
            default:
                Terminal.WriteLine("Invalid input, repeat:");
                break;
        }
    }
    void RandomizePassword()
    {
        switch (level)
        {
            case 1:
                CorrectPassword=Easy[UnityEngine.Random.Range(0, 5)];
                break;
            case 2:
                CorrectPassword = Medium[UnityEngine.Random.Range(0, 5)];
                break;
            case 3:
                CorrectPassword = Hard[UnityEngine.Random.Range(0, 5)];
                break;
        }
    }
    private void StartGame()
    {
        currentScreen = Screen.Password;
        RandomizePassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("You have choosen level " + level);
        Terminal.WriteLine("enter you password: ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
