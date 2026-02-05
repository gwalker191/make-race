using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money = 100;
    public UIManager uiManager;

    void Start()
    {
        money = SaveSystem.LoadMoney();
        if (uiManager != null) uiManager.UpdateMoney(money);
    }

    public void AwardMoney(int amount)
    {
        money += amount;
        SaveSystem.SaveMoney(money);
        if (uiManager != null) uiManager.UpdateMoney(money);
    }

    public void OnPlayerFinish()
    {
        // Simple reward for finishing a level
        AwardMoney(50);
        if (uiManager != null) uiManager.ShowPostRace(true, 50);
    }
}
