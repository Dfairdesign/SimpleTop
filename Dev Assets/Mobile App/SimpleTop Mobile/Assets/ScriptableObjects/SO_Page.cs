/*******************************************************************************
File: SO_Page.cs
Author: Dylan Fair
Date: 1/9/2023

Description:
    Contains Section Headers, body text, and images.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Page", menuName = "Page")]
public class SO_Page : ScriptableObject
{
    public List<string> Headers;
    [SerializeField]
    public List<List<string>> Bodies;

    private void OnEnable()
    {
        //each header creates a list with a string
        for (int i = 0; i < Headers.Count; i++)
        {
            //Create placeholder list and string to be changed later
            List<string> newList = new List<string>();
            string newString = "";

            //Add placeholder vars to Bodies Lists
            Bodies.Add(newList);
            Bodies[i].Add(newString);
        }
    }
}