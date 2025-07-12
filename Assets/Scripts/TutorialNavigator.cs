using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialNavigator : MonoBehaviour
{
    public List<GameObject> tutorialPages;
    public Button nextButton;
    public Button backButton;

    [Tooltip("Scene to load when Back is clicked on the first page.")]
    public string targetSceneName = "main menu"; 
    private int currentPageIndex = 0;

    void Start()
    {
        ShowPage(currentPageIndex);

        nextButton.onClick.AddListener(NextPage);
        backButton.onClick.AddListener(BackClicked);
    }

    void ShowPage(int index)
    {
        for (int i = 0; i < tutorialPages.Count; i++)
        {
            tutorialPages[i].SetActive(i == index);
        }

        nextButton.interactable = index < tutorialPages.Count - 1;
    }

    void NextPage()
    {
        if (currentPageIndex < tutorialPages.Count - 1)
        {
            currentPageIndex++;
            ShowPage(currentPageIndex);
        }
    }

    void BackClicked()
    {
        if (currentPageIndex == 0)
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            currentPageIndex--;
            ShowPage(currentPageIndex);
        }
    }
}
