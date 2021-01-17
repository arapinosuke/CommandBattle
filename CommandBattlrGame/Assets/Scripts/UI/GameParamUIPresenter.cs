using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParamUIPresenter : MonoBehaviour
{
    public CharacterHPViewer CharacterHpviewer = null;

    public WaitGaugeViewer WaitGaugeViewer=null;

    public CenterUIViewer CenterUIViewer = null;

    public void SetCharacterParamViewer(CharacterParam[] CharacterParams)
    {
        for(int i=0;i<3;i++)
        {
            if(CharacterParams[i]!=null)
            {
                CharacterHpviewer.CharacterMaxHps[i] = CharacterParams[i].HitPoint;
                CharacterHpviewer.CharacterHps[i] = CharacterParams[i].HitPoint;

                WaitGaugeViewer.CharacterSpeeds[i] = CharacterParams[i].Speed;
            }
        }
        WaitGaugeViewer.Init();
    }
}
