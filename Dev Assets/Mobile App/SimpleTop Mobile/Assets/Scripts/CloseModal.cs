/*******************************************************************************
File: CloseModal.cs
Author: Dylan Fair
DP Email: dylan.fair@digipen.edu
Date: 12/11/2023
Course: CS176
Section: B

Description:
    Destroys this object or calls ModalManager's DespawnTopModal function.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseModal : MonoBehaviour
{
    ModalManager MM;

    private void Start()
    {
        MM = FindAnyObjectByType<ModalManager>();
    }


    public void DespawnTopModal()
    {
        MM.DeSpawnTopModal();
    }
}
