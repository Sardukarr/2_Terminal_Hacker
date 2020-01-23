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
        {
            DispayWinScreen();
        }
        else if (retries > 0)
        {
            Terminal.WriteLine("wrong password, try again:");
            retries--;
        }
        else
        { 
            Terminal.WriteLine("wrong password, calling security");
            Terminal.WriteLine("Run! type 'menu':");
            currentScreen = Screen.MainMenu;
        }
    }
    void DispayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        currentScreen = Screen.MainMenu;
    }



    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        switch (input)
        {
            case "General Kenobi":
                Terminal.WriteLine("I've been expecting you");
                break;
            case "menu":
            case "Menu":
            case "MENU":
                ShowMainMenu();
                break;
            default:
                if (isValidLevel)
                {
                    level = int.Parse(input);
                    StartGame();
                }
                else
                { 
                    Terminal.WriteLine("Invalid input, repeat:");
                    Debug.Log("wrong level");
                }
                break;
        }
    }
    void RandomizePassword()
    {
        switch (level)
        {
            case 1:
                CorrectPassword=Easy[UnityEngine.Random.Range(0, Easy.Length)];

                break;
            case 2:
                CorrectPassword = Medium[UnityEngine.Random.Range(0, Medium.Length)];
                break;
            case 3:
                CorrectPassword = Hard[UnityEngine.Random.Range(0, Hard.Length)];
                break;
        }
        Debug.Log(CorrectPassword);
    }
    private void StartGame()
    {
        currentScreen = Screen.Password;
        RandomizePassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("You have choosen level " + level);
        Terminal.WriteLine("enter you password, hint: " + CorrectPassword.Anagram());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowLevelReward()
    {
        Terminal.WriteLine("Succes, You're in.");
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
       ___________
      |.---------.|
      || you're  ||
      ||         ||
      || IN!     ||
      |'---------'|
       `)__ ____('
       [=== -- o ]--.
     __'---------'__ \
    [::::::::::: :::] )
     `''''''''''''''`/T\
                     \_/");
                break;
            case 2:
                Terminal.WriteLine(@"
               _A
             .'`'`'.
            /   , , \ 
           |   <\^/> |
           |  < (_) >|
           /   ====  \
          (.--._ _.--.)
           |\  -`\- /|
           |(_- > -.)|
           \__- '^'._ /
            |\   .  /
         _.'\ '----'|' -.
     _.- '  O ;-.__.' \O `o.
     / o \      \/ -.-\/|   \
    |    ;,     '.|\| /
hold on right there!");
                break;
            case 3:
                Terminal.WriteLine(@"
       .-""""-.        .-""""-.
     /_        _\    /_        _\
    // \      / \\  // \      / \\
    |\__\    /__/|  |\__\    /__/|
     \    ||    /    \    ||    /
      \        /      \        /
       \  __  /        \  __  / 
        '.__.'          '.__.'
         |  |            |  | 
you are coming with us");
                break;
        }
    }
}
