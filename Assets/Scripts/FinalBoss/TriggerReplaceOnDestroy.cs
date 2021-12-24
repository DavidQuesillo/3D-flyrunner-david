using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReplaceOnDestroy : MonoBehaviour
{
    [SerializeField] private TurretReplace tr;

    private void OnDestroy()
    {
        tr.TriggerReplace();
    }

    public void setTr(TurretReplace script)
    {
        tr = script;
    }
}
