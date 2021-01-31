using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    string password;
    Screen currentScreen;

    // Game confugation data
    const string menuHint = "Type menu to return to the menu.";
    string[,] passwordArray = new string[3,3] {
        { "books", "password", "borrow" },
        { "prisoner", "handcuuffs", "holster"},
        { "starfield", "telescope", "environment"}
    };
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
        Terminal.WriteLine("Press 3 for NASA");
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
        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    void RunPasswordGuess(string input)
    {
        if (input.ToLower() == password)
        {
            RunWin();
        } else
        {
            AskForPassword();
        }
    }

    void RunWin()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();

        Terminal.WriteLine(menuHint);
    }

     void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book: ");
                Terminal.WriteLine(@" 
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\     
 //________.|.________\\    
`----------`-'----------'
                ");
                break;
            case 2:
                Terminal.WriteLine("Have a key: ");
                Terminal.WriteLine(@" 
  ooo,    .---.
 o`  o   /    |\________________
o`   'oooo()  | ________   _   _)
`oo   o` \    |/        | | | |
  `ooo'   `---'         '-' |_|

                ");
                break;
            case 3:
                Terminal.WriteLine(@" 
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                ");
                Terminal.WriteLine("Welcome to NASA's internal system! ");

                break;
        }   
    }


    void AskForPassword()
    {
        currentScreen = Screen.Password;
        password = passwordArray[level - 1, Random.Range(0, passwordArray.GetLength(1))];
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your password:, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

}
