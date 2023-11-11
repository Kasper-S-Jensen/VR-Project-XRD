using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameEvent restartEvent;
    public GameEvent mainMenuEvent;
    public GameEvent spawnBowEvent;

    public void RestartButton()
    {
        restartEvent.Raise();
    }

    public void SpawnBow()
    {
        spawnBowEvent.Raise();
    }

    public void MainMenu()
    {
        mainMenuEvent.Raise();
    }
}