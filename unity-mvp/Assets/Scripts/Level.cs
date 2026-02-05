using UnityEngine;

public abstract class Level : MonoBehaviour
{
    public string levelName;
    public float trackLengthMeters = 100f;
    public GameManager gameManager;

    public virtual void OnLevelStart()
    {
        Debug.Log($"Level {levelName} started.");
    }

    public virtual void OnPlayerFinish(float time)
    {
        Debug.Log($"Level {levelName} finished in {time}s.");
        gameManager.OnPlayerFinish();
    }

    public virtual void OnPlayerFail(string reason)
    {
        Debug.Log($"Level {levelName} failed: {reason}");
    }
}
