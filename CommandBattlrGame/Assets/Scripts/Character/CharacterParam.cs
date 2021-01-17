using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParam 
{
    public enum GameCharacterType
    {
        Invalide,
        Attacker,
        SpellCaster,
        Healer,
    }

    public int HitPoint;
    public int MagicPoint;
    public float Speed;
    public GameCharacterType CharacterType;

    public Action FirstButtonAction;
    public Action SecondButtonAction;
    public Action ThirdButtonAction;
    public Action FourthButtonAction;
}
