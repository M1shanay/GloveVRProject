using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzleChapter : Chapter
{
    public CubePuzzleCCManager CheckCollider;
    public override string Title { get; } = "Вставьте все объекты в рамку по цветам!";
    // Start is called before the first frame update
    public override void StartTask()
    {
        StartChapter();
    }
    protected override void ChapterRunning()
    {
        Debug.Log("processing");
        Debug.Log(CheckCollider._completedRow);
        if (CheckCollider.CheckColliders())
        {
            _mark = true;
            Debug.Log("ended");
        }
    }
}
