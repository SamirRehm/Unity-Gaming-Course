using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

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
        Terminal.WriteLine("Press 3 for NASA");
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
            Terminal.WriteLine("Well Done!");
        }
        else
        {
            Terminal.WriteLine("Please try again");
        }
    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "donkey";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "combobulate";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter a password");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
