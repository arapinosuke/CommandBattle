using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatonController : MonoBehaviour
{
    public Animator CharacterAnimator = null;

    private const string AttackAnimationName = "Attack";

    private const string IdleAnimationName = "Idle";

    private const string GoToMoveName = "GoToMove";

    private const string ReturnMOveName = "ReturnMove";

    public Transform CharacterRoot = null;

    public Transform AttackRoot = null;

    public enum CharacterType
    {
        Invalide,
        Attacker,
        SpellCaster,
        Healer,
    }

    public CharacterType characterType = CharacterAnimatonController.CharacterType.Invalide;

    private void Awake()
    {
        CharacterAnimator = GetComponent<Animator>();
    }


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(StartAttackanimation(2));
        }
    }

    public IEnumerator StartAttackanimation(int attackId)
    {
        //キャラクタータイプがAttackerだったら行って攻撃、戻ってくるの処理
        if (characterType == CharacterType.Attacker)
        {
            yield return StartCoroutine(StartMove());
            yield return StartCoroutine(StartAnimation(attackId));
            yield return StartCoroutine(ReturnMove());
        }
        else
        {
            yield return StartCoroutine(StartAnimation(attackId));
        }
    }

    IEnumerator StartMove()
    {
        var distance_two = Vector3.Distance(transform.position, AttackRoot.position);
        var elapsedTime = 0f;
        var waitTime = 1f;
        SetAttackAnimation(2);
        while(elapsedTime<waitTime)
        {
            this.transform.position = Vector3.Lerp(transform.position, AttackRoot.position, (elapsedTime / waitTime) / distance_two);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator StartAnimation(int attackNo)
    {
        
        SetAttackAnimation(attackNo);
        Debug.Log(CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(GoToMoveName));
        //Idleの間に待つを消した
        
        if (characterType == CharacterType.Attacker)
        {
            //GotoMoveの間待つ
            yield return new WaitWhile(() => CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(GoToMoveName));
        }
        //Attackの間待つ
        yield return new WaitWhile(() =>
        CharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f &&
        CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimationName));
        //Attackの値を0に戻す
        CharacterAnimator.SetInteger(AttackAnimationName, 0);
    }

    IEnumerator ReturnMove()
    {
        Debug.Log("aaa");
        var distance_two = Vector3.Distance(transform.position, CharacterRoot.position);
        var elapsedTime = 0f;
        float waitTime = 1f;
        SetAttackAnimation(3);
        while(this.transform!=CharacterRoot&&elapsedTime<waitTime)
        {
            this.transform.position = Vector3.Lerp(transform.position, CharacterRoot.position, (elapsedTime / waitTime) / distance_two);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void SetAttackAnimation(int attackNo)
    {
        if(CharacterAnimator==null)
        {
            return;
        }
        CharacterAnimator.SetInteger(AttackAnimationName, attackNo);
    }
}
