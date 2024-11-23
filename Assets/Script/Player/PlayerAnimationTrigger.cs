using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTri : MonoBehaviour
{
    private Player Player=>GetComponentInParent<Player>();
   private void AnimationTrigger()
    {
        Player.AnimiationTrigger();
    }
    private void AttackTrigger()//检测在攻击范围里是否存在敌人 如果 存在 则转入毁坏方法
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Player.attackCheck.position, Player.attackCheckRadius);
        foreach(var hit in colliders)
        {
            if(hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }
}
