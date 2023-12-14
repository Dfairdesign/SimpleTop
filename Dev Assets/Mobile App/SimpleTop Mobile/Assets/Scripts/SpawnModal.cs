/*******************************************************************************
File: SpawnModal.cs
Author: Dylan Fair
DP Email: dylan.fair@digipen.edu
Date: 12/11/2023
Course: CS176
Section: B

Description:
    Finds the Modal Manager and calls its Spawn function, passing the given modal.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModal : MonoBehaviour
{
    ModalManager MM;

    private void Start()
    {
        MM = FindAnyObjectByType<ModalManager>();
    }


    public void SpawnModalOnTop(GameObject modal)
    {
        MM.SpawnModal(modal);
    }


    public void ReplaceTopModal(GameObject modal)
    {
        MM.ReplaceModal(modal);
    }
}
