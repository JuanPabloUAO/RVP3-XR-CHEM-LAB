using System;

public static class GameEvents
{
    public static Action<int> OnScoreChanged;

    public static Action<float> OnTimerChanged;

    public static Action OnGameStarted;

    public static Action OnGameEnded;

    public static Action OnCorrectReaction;

    public static Action OnBadReaction;
}