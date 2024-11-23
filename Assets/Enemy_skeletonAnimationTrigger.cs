using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_skeletonAnimationTrigger : MonoBehaviour
{
    private Enenmy_skeleton enemy => GetComponentInParent<Enenmy_skeleton>(); 
    private void AnimationTrigger()
    {
       enemy.AnimationFinishTrigger();
    }
    private void AttackTrigger()//����ڹ�����Χ���Ƿ���ڵ��� ��� ���� ��ת��ٻ�����
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Player >().Damage();
            }
        }
    }
}
