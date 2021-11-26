using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropsBase : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float timerBeforeFollow = 0.8f;
    //private bool follow = false;
    [SerializeField] private float waitBeforeTouch = 0.3f;

    Tweener tweener;

    //[SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameManager.instance.player.transform;
        MoveToPlayer();
    }

    
    /*void Update()
    {
        if (timerBeforeFollow > 0f)
        {
            timerBeforeFollow -= Time.deltaTime;
        }
        else
        {
            //rb.MovePosition(Vector3.MoveTowards(transform.position, player.position, speed));
        }
    }*/

    public virtual void ConsumeDrop()
    {
        ApplyEffect();
        tweener.Kill();
        //DOTween.KillAll();
        Destroy(gameObject);
    }

    public virtual void MoveToPlayer()
    {
        //transform.SetParent(GameManager.instance.player.transform);
        tweener = transform.DOMove(GameManager.instance.player.transform.position, waitBeforeTouch).SetDelay(timerBeforeFollow).OnComplete(ApplyEffect);
        tweener.OnUpdate(UpdatePlayerPosition);
    }

    public virtual void ApplyEffect()
    {

    }

    void UpdatePlayerPosition()
    {
        tweener.ChangeEndValue(GameManager.instance.player.transform.position, true);
    }

}
