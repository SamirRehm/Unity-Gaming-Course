using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    string[] level1passwords = { "books", "aisle", "shelf", "password", "font", "borrow"};
    string[] level2passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

	// Use this for initialization
	void Start () {
        showMainMenu();
	}

    void showMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            showMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevel = ( input == "1" || input == "2" );
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter a password; hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level numbers");
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
