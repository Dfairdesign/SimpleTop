/*******************************************************************************
File: ModalManager.cs
Author: Dylan Fair
Updated: 12/8/2023

Description:
    Does Stuff
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalManager : MonoBehaviour
{
    [Tooltip("How many children to ignore when removing modals.")]
    public int StaticChildren;

    List<Transform> ActiveModals = new List<Transform>();


    private void Start()
    {
        //Add all existing modals to the list
        for (int i = 0; i < transform.childCount; i++)
            ActiveModals.Add(transform.GetChild(i));
    }


    public void SpawnModal(GameObject modalToSpawn)
    {
        GameObject modal = Instantiate(modalToSpawn, gameObject.transform);

        ActiveModals.Add(modal.transform);
    }


    public void ReplaceModal(GameObject modalToSpawn)
    {
        if (transform.childCount > StaticChildren)
            DeSpawnTopModal();

        SpawnModal(modalToSpawn);
    }


    public void DeSpawnTopModal()
    {
        //Find the topmost modal
        GameObject modalToRemove = transform.GetChild(transform.childCount - 1).gameObject;

        //Remove modal from list and destroy it
        ActiveModals.Remove(modalToRemove.transform);
        Destroy(modalToRemove);
    }
}
