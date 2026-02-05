using UnityEngine;

public class GarageManager : MonoBehaviour
{
    public CarTemplate[] templates;
    public int selectedIndex = 0;
    public GameManager gameManager;

    public void Select(int idx)
    {
        if (idx >= 0 && idx < templates.Length) selectedIndex = idx;
    }

    public CarTemplate GetSelected()
    {
        if (templates == null || templates.Length == 0) return null;
        return templates[selectedIndex];
    }
}
