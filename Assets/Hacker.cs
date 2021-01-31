using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string[,] passwordArray = new string[,] { { "books", "password", "borrow" }, { "prisoner", "handcuuffs", "holster"} };
    string password;

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

        Terminal.WriteLine("Type menu to return to the menu.");
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
        }   
    }


    void AskForPassword()
    {
        currentScreen = Screen.Password;
        password = passwordArray[level - 1, Random.Range(0, passwordArray.GetLength(level - 1))];
        Terminal.WriteLine("Enter your password:, hint: " + password.Anagram());
    }

}
