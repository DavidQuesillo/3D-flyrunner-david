using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitAnim : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void PlayEffect()
    {
        anim.SetTrigger("gotshot");
    }
}
