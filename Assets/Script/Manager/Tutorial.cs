using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] Page;
    public int i = 0;
    public Animator animator1;
    public Animator animator2;
    public GameObject tutorial;

    private void Update()
    {
        nextpage();
    }
    public void nextpage()
    {
        if(i == 0)
        {
            Page[i].SetActive(true);
        }
        else
        {
            Page[i].SetActive(true) ;
            Page[i-1].SetActive(false);
        }
        
    }

    public void ChangePage()
    {
        var lastpage = Page.Length - 1;
        if (i == lastpage)
        {
            i = 0;
            Page[lastpage].SetActive(false);
        }

        else if(i < Page.Length)
        {
            i++;
        }
    }

    public void Exit()
    {
        animator1.Play("TutorialDisappear");
        animator2.Play("MainMenuAppear");
    }
    public void tutorialexit()
    {
        tutorial.SetActive(false);
    }
}
