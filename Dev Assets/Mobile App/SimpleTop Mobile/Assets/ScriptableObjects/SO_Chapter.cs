/*******************************************************************************
File: SO_Chapter.cs
Author: Dylan Fair
Date: 1/9/2023

Description:
    Does Stuff
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chapter", menuName = "Chapter")]
public class SO_Chapter : ScriptableObject
{
    public List<SO_Page> Pages;
}
