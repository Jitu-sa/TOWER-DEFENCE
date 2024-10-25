using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int StartingBalance = 150;
    [SerializeField] TextMeshProUGUI DisplayBalance;

    [SerializeField] int CurrentBalance;
    public int CURRENTBALANCE { get {  return CurrentBalance; } }
    void Awake()
    {
        CurrentBalance = StartingBalance;
        DisplayBalanceOnScreen();
    }

    public void Deposit(int amount)
    {
        CurrentBalance += Mathf.Abs(amount);
        DisplayBalanceOnScreen();
    }

    public void Withdrawl(int amount)
    {
        CurrentBalance -= Mathf.Abs(amount);
        DisplayBalanceOnScreen();

        if (CurrentBalance<0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void DisplayBalanceOnScreen()
    {
        DisplayBalance.text = "GOLD:" + CurrentBalance;
    }
}
