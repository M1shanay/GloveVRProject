using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearChapter : Chapter
{
    public LineirColliderCheck CheckCollider;
    public override string Title { get; } = "Выведите красный блок!";
    public override void StartTask()
    {
        StartChapter();
    }
    protected override void ChapterRunning()
    {
        Debug.Log("processing");
        if (CheckCollider.Complete == true)
        {
            _mark = true;
            Debug.Log("ended");
        }
    }
}
