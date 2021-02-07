using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    private int latestLevel, crashCount, winCount, money;

    public Data()
    {

    }

    public void SetLatestLevel(int level)
    {
        this.latestLevel = level;
    }

    public void IncreaseCrashCount()
    {
        this.crashCount++;
    }

    public void IncreaseWinCount()
    {
        this.winCount++;
    }

    public void IncreaseMoney(int money)
    {
        this.money += money;
    }

    public int GetLatestLevel()
    {
        return this.latestLevel;
    }

    public int GetCrashCount()
    {
        return this.crashCount;
    }

    public int GetWinCount()
    {
        return this.winCount;
    }

    public int GetMoney()
    {
        return this.money;
    }
}
