using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string[] password = { "first", "second" };
    Screen currentScreen;
    enum Screen { MainMenu, Password, Win };
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;

        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input.ToLower() == "menu")
        {
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu)
        {
            RunMainManu(input);
        } else if (currentScreen == Screen.Password)
        {
            Terminal.print("input" + input);
            RunPasswordGuess(input);
        }
    }

    void RunMainManu(string input)
    {
        if (input == "1" || input == "2")
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    void RunPasswordGuess(string input)
    {
        Terminal.print("testGuess");

        if (input.ToLower() == password[level - 1])
        {
            Terminal.print("testWin");
            RunWin();
        } else
        {
            RunIncorrect(input);
        }
    }

    void RunWin()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("congratulations. The password " + password[level - 1] + " was Right!" );
        Terminal.WriteLine("Type menu to return to the menu.");
    }

    void RunIncorrect(string input)
    {
        Terminal.WriteLine(input + " is incorrect!");
        Terminal.WriteLine("Please enter your password: ");

    }


    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

}
