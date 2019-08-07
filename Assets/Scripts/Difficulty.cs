using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float MaxDifficultyTime = 60;

    public static float getTime()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / MaxDifficultyTime);
    }
}
