using System;

[Serializable]
public class LevelProgressData
{
    public int lastUnlockedLevel;

    public LevelProgressData(int lastUnlockedLevel)
    {
        this.lastUnlockedLevel = lastUnlockedLevel;
    }
}