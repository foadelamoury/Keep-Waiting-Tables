using System.Diagnostics; // Required for the Conditional attribute
using UnityEngine;

public static class Logging
{
    // The loggers can stay private now, as we will access them through the methods below
    private static Logger combatLogger = new Logger(UnityEngine.Debug.unityLogger.logHandler);
    private static Logger playerLogger = new Logger(UnityEngine.Debug.unityLogger.logHandler);

    // Initialization is optional if you just want them always enabled when in dev mode
    public static void LoadLoggers()
    {
        combatLogger.logEnabled = true;
        playerLogger.logEnabled = true;
    }

    // This method entirely disappears from the compiled code UNLESS 
    // it's running in the Unity Editor or a Development Build.
    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void LogCombat(string message)
    {
        combatLogger.Log(message);
    }

    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void LogPlayer(string message)
    {
        playerLogger.Log(message);
    }
}