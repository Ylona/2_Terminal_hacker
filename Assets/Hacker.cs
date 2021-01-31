using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string[,] passwordArray = new string[,] { { "books", "password", "borrow" }, { "prisoner", "handcuuffs", "holster"} };
    int passwordNr;

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
        if (input.ToLower() == passwordArray[level - 1, Random.Range(0, passwordArray.GetLength(level - 1))])
        {
            RunWin();
        } else
        {
            RunIncorrect(input);
        }
    }

    void RunWin()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine("Congratulations!");

        Terminal.WriteLine("Type menu to return to the menu.");
    }

    void RunIncorrect(string input)
    {
        Terminal.WriteLine("Wrong password ");

    }


    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

}
