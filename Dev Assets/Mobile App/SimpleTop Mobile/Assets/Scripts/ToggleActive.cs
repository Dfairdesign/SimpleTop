/*******************************************************************************
File: ToggleActive.cs
Author: Dylan Fair
DP Email: dylan.fair@digipen.edu
Date: 12/11/2023
Course: CS176
Section: B

Description:
    Contains a public function that toggles the active state of this gameobject. 
Also has a bool to determine if the object sets itself inactive on start. 
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    //Getters & Setters
    bool _Active;
    public bool Active
    {
        get => _Active;

        set
        {
            _Active = value;
            gameObject.SetActive(value);
        }
    }

    //public variables
    public bool InactiveOnStart = false;


    private void Start()
    {
        gameObject.SetActive(!InactiveOnStart);
    }


    public void ToggleGOActive()
    {
        Active = !Active;
    }
}
