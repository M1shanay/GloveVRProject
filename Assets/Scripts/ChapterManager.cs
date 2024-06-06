using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChapterManager : MonoBehaviour
{
    public ChapterEnvir DefaultEnvir;
    public UIManager TextManager;
    public List<Chapter> Chapters;
    public GameObject StartButton;
    private bool _start = false;


    void Start()
    {
        TextManager.ChangeMenuText("Для начала нажмите кнопку!");
        StartCoroutine(ChapterChanger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonFunction()
    {
        _start = true;
        StartButton.SetActive(false);
    }
    private IEnumerator ChapterChanger()
    {
        foreach (var chapter in Chapters)
        {

            yield return new WaitUntil(() => _start);
            DefaultEnvir.DeactivateEnvironment();
            yield return new WaitForSeconds(2f);
            chapter.Environment.ActivateEnvironment();
            chapter.gameObject.SetActive(true);
            TextManager.ChangeChapterText(chapter.Title);
            yield return new WaitForSeconds(2f);
            chapter.StartTask();
            yield return new WaitUntil(() => chapter.IsFinished);
            chapter.Environment.DeactivateEnvironment();
            DefaultEnvir.ActivateEnvironment();
            _start = false;
            StartButton.SetActive(true);
            TextManager.ChangeMenuText("Для следующего задания нажмите кнопку!");

        }
        yield return null;
    }
}
