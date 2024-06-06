using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlesChapter : Chapter
{
    public CheckCollider CheckCollider;
    public override string Title { get; } = "Вставьте все фигуры в рамку!";
    // Start is called before the first frame update
    public override void StartTask()
    {
        StartChapter();
    }
    protected override void ChapterRunning()
    {
        Debug.Log("processing");
        if (CheckCollider.Entities == CheckCollider.MaxEntities)
        {
            _mark = true;
            Debug.Log("ended");
        }
    }
}
