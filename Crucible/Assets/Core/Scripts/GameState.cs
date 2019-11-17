﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum LastMinigameFinish
{
    WON,
    LOST,
    P1WIN,
    P2WIN,
    TIE,
    NONE
};

[System.Serializable]
public struct GameWinValues
{
    public int meteorMasher;
    public int shotPot;
}


/** Persistent singleton (never deleted after creation) used to keep track the current state of the game. 
 *  If you are not the lead for the minigame project please DO NOT MODIFY this file. 
 *  Talk to the lead if you need something here to change.*/
public class GameState : UnitySingletonPersistent<GameState>
{
    public LastMinigameFinish LastMinigameFinishState;
    public int MinigamesWon = 0;
    public int MinigamesPlayed = 0;
    public int MinigamesWonByP1 = 0;
    public int MinigamesWonByP2 = 0;
    public int ScorePlayer1 = 0;
    public int ScorePlayer2 = 0;
    public MinigameInfo[] SelectedMinigames;
    public MinigameInfo CurrentMinigame;
    public int WinningScore = 10;
    public MinigameGamemodeTypes Gamemode;
    public GameWinValues winVals = new GameWinValues
    {
        meteorMasher = 3,
        shotPot = 2
    };

    /** A scene might be launched not from the minigame launcher but directly. In that case, the game state will not be valid.*/
    public bool IsGameStateValid()
    {
        return SelectedMinigames != null && SelectedMinigames.Length > 0 && MinigamesPlayed < SelectedMinigames.Length;
    }

    public void SetupNewMinigames(MinigameInfo[] NewSelectedMinigames, MinigameGamemodeTypes NewGamemode)
    {
        MinigamesWon = 0;
        MinigamesPlayed = 0;
        MinigamesWonByP1 = 0;
        MinigamesWonByP2 = 0;
        LastMinigameFinishState = LastMinigameFinish.NONE;
        SelectedMinigames = NewSelectedMinigames;
        Gamemode = NewGamemode;
    }

    public void FinishMinigame(LastMinigameFinish FinishState)
    {
        MinigamesPlayed++;
        switch(FinishState)
        {
            case LastMinigameFinish.LOST:
                break;
            case LastMinigameFinish.WON:
                MinigamesWon++;
                break;
            case LastMinigameFinish.TIE:
                break;
            case LastMinigameFinish.P1WIN:
                UpdateMetaScore(0);
                MinigamesWonByP1++;
                break;
            case LastMinigameFinish.P2WIN:
                UpdateMetaScore(1);
                MinigamesWonByP2++;
                break;
            case LastMinigameFinish.NONE:
            default:
                break;
        }
    }

    public void UpdateMetaScore(int winningPlayer)
    {
        string gameName = CurrentMinigame.name.ToLower();

        switch (gameName)
        {
            case "meteor masher":
                AddMetaScore(winningPlayer, winVals.meteorMasher);
                break;
            case "shotpot":
                AddMetaScore(winningPlayer, winVals.shotPot);
                break;
        }
    }

    public void AddMetaScore(int player, int score)
    {
        if (player == 0)
        {
            ScorePlayer1 += score;
        } else
        {
            ScorePlayer2 += score;
        }
    }
}

