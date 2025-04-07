using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] Page;
    private int i = 0;

    private void nextpage()
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
        if(i == Page.Length)
        {
            i = 0;
            Page[i].SetActive(true) ;
            Page[Page.Length].SetActive(false) ;
        }
    }

    public void ChangePage()
    {
        i++;
    }
}
