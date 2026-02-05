using UnityEngine;

public static class SaveSystem
{
    const string MoneyKey = "MR_Money";

    public static void SaveMoney(int money)
    {
        PlayerPrefs.SetInt(MoneyKey, money);
        PlayerPrefs.Save();
    }

    public static int LoadMoney()
    {
        return PlayerPrefs.GetInt(MoneyKey, 100);
    }
}
