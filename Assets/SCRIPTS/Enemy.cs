using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int GoldReward = 25;
    [SerializeField] int GoldPenalty = 100;

    Bank bank;
    void Start()
    {
        bank=FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank==null){ return; }
        bank.Deposit(GoldReward);
    }

    public void PenaltyGold()
    {
        if (bank == null) { return; }
        bank.Withdrawl(GoldPenalty);
    }
}
