using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirStructure : MonoBehaviour
{
    public StructureFloor LastFloor;

    private bool _complited = false;

    public bool IsComplited
    {
        get { return _complited; }
    }
    void Start()
    {
        StartCoroutine(CheckComplited());
    }

    private IEnumerator CheckComplited()
    {
        while(!_complited)
        {
            if (LastFloor.IsEnded)
            {
                _complited = true;
                Debug.Log("End");
            }
            yield return null;
        }
        yield return null;
    }
}
