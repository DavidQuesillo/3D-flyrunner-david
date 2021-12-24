using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretReplace : MonoBehaviour
{
    [SerializeField] private float wait = 5f;
    [SerializeField] private float ascentSpeed = 1f;
    [SerializeField] private GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerReplace()
    {
        StartCoroutine(ReplaceDeadTurret());
        //GameObject turret = Instantiate(prefab, transform.position,Quaternion.identity, null);
        //turret.GetComponent<TriggerReplaceOnDestroy>().setTr(this);
    }

    private IEnumerator ReplaceDeadTurret()
    {
        yield return new WaitForSeconds(wait);
        /*GameObject turret = Instantiate(prefab, transform.position - Vector3.down * 2, Quaternion.identity, transform);
        while (turret.transform.position.y < transform.position.y)
        {
            turret.transform.Translate(Vector3.up * ascentSpeed * Time.deltaTime);
        }
        turret.transform.position = transform.position;*/

        GameObject turret = Instantiate(prefab, transform.position, Quaternion.identity, null);
        turret.GetComponent<TriggerReplaceOnDestroy>().setTr(this);
        yield break;
    }
}
