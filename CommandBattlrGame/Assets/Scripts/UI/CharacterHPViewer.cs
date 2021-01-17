using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CharacterHPViewer : MonoBehaviour
{
    public int[] CharacterHps = new int[3];
    public int[] CharacterMaxHps = new int[3];
    public TextMeshProUGUI[] CharacterHPTexts = new TextMeshProUGUI[3];

    public void SetHp(int CharacterPos,int hp)
    {
        CharacterHps[CharacterPos] = hp;
    }

    public void SetMaxHp(int characterPos,int maxHo)
    {
        CharacterMaxHps[characterPos] = maxHo;
    }

    public void HpTextUpDate()
    {
        for(int i=0; i<3; i++)
        {
            CharacterHPTexts[i].text=$"{CharacterHps[i]}/{CharacterMaxHps[1]}";
        }
    }

    //Updateで計算をした後にHpの繁栄が入るようにLateUpDateを使用する
    private void LateUpdate()
    {
        HpTextUpDate();
    }
}
