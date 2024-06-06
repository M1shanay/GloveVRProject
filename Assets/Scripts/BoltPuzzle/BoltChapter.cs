using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltChapter : Chapter
{
    public List<CheckCollider> CheckColliders;
    public override string Title { get; } = "Вставьте все болты в рамку!";
    // Start is called before the first frame update
    public override void StartTask()
    {
        StartChapter();
    }
    protected override void ChapterRunning()
    {
        Debug.Log("processing");
        if (AllIn())
        {
            _mark = true;
            Debug.Log("ended");
        }
    }
    private bool AllIn()
    {
        int _ent = 0;
        foreach (CheckCollider collider in CheckColliders)
        {
            if (collider.Entities == collider.MaxEntities)
            {
                _ent++;
            }
        }
        if(_ent == CheckColliders.Count)
            return true;
        else
            return false;
    }
}
