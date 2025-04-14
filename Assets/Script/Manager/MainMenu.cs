using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button LoadButton;
    [SerializeField] private string loadScene;
    [SerializeField] private Animator animator1;
    [SerializeField] private Animator animator2;
    private int enemyKilledTotal;
    public GameObject tutorial;
    public TMP_Text EnemyDeath;
    private void Start()
    {
        if (!Datapresistence.instance.HasGameData())
        {
            LoadButton.interactable = false;
        }
        loadScene = Datapresistence.loadedScene;
        enemyKilledTotal = Datapresistence.TotalEnemyKiled;
        EnemyDeath.SetText(enemyKilledTotal.ToString());
    }
    public void OnNewGameClicked()
    {
        Datapresistence.instance.NewGame();
        SceneManager.LoadSceneAsync("BaseVillage");
    }
    public void OnLoadGameClicked()
    {
        SceneManager.LoadSceneAsync(loadScene);
    }

    public void Tutorial()
    {
        tutorial.SetActive(true);
        animator1.Play("MainMenuDisappear");
        animator2.Play("TutorialAppear");
    }
}
