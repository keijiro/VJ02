using UnityEngine;
using System.Collections;

public class XorSwitcher : MonoBehaviour
{
    public Behaviour target;
    public Behaviour[] args;

    bool GetLogicalOrOfArgs()
    {
        foreach (var b in args)
            if (b.enabled) return true;
        return false;
    }

    void Update()
    {
        target.enabled = !GetLogicalOrOfArgs();
    }
}
