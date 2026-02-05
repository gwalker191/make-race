using UnityEngine;

public class Level1Manager : Level
{
    public Transform startLine;
    public Transform finishLine;
    private float raceStartTime;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        OnLevelStart();
        raceStartTime = Time.time;
    }

    void Update()
    {
        // Check if player crossed finish line (handled by FinishLine script)
        // This is just the level controller
    }

    public float GetRaceTime()
    {
        return Time.time - raceStartTime;
    }

    public override void OnLevelStart()
    {
        base.OnLevelStart();
        Debug.Log("Level 1 (Drag Race) Started. Drive forward to the finish line!");
    }

    public override void OnPlayerFinish(float time)
    {
        base.OnPlayerFinish(time);
        Debug.Log($"Great job! Finished in {time:F2} seconds.");
    }
}
