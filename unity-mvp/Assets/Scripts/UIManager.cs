using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text moneyText;
    public GameObject postRacePanel;
    public Text postRaceText;

    public void UpdateMoney(int money)
    {
        if (moneyText != null) moneyText.text = "$" + money.ToString();
    }

    public void ShowPostRace(bool win, int reward)
    {
        if (postRacePanel != null && postRaceText != null)
        {
            postRacePanel.SetActive(true);
            postRaceText.text = (win ? "Win!\n" : "Fail!\n") + "You earned $" + reward.ToString();
        }
    }
}
