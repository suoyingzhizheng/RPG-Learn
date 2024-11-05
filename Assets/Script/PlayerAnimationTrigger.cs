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
}
