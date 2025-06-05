using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]
public class Players : ScriptableObject
{
    public string names;
    public string description;
    public float force;
    public float jumpforce;
    public int Health;
}
