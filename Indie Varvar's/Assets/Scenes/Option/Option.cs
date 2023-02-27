using UnityEngine;

public static class Option
{
    public static Audio Audio { get; } = new Audio();
    public static GameScreen GameScreen { get; } = new GameScreen();
    public static Quality Quality { get; } = new Quality();
}
