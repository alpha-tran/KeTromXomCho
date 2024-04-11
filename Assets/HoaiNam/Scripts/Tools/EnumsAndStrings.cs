using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public static class Strings
{
    public static class BlockStrings
    {
        public static readonly string[] BLOCKS = { "MapBlock_E 1", "MapBlock_E 2", "MapBlock_E 3", "MapBlock_E 4", "MapBlock_E 5", "MapBlock_E 6" };

    }
}


public static class Enums
{
    public enum StateName
    {
        MainMenu,
        Gameplay
    }


    public enum UIType
    {
        Unknown,
        Screen,
        Popup,
        Overlap,
        Notify,
    }


    public enum EventID
    {
        // ui
        OnStartGame,
        BackToMainMenu,
        PlayAgain,
        OnEndGame,



        // gameplay
        PlayerGainMoney,
        PlayerDead,
        PlayerLoseMoney,
        OnMoneyChanged,
    }
}