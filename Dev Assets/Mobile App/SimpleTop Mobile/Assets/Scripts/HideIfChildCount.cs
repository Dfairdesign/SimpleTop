/*******************************************************************************
File: HideIfChildCount.cs
Author: Dylan Fair
DP Email: dylan.fair@digipen.edu
Date: 12/11/2023
Course: CS176
Section: B

Description:
    Sets a given GameObject inactive depending on another object's childCount.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfChildCount : MonoBehaviour
{
    public GameObject ObjectToSet;
    public Transform ObjectWithChildren;

    [Tooltip("Change this value if you want ObjectToSet to hide when " +
        "ObjectWithChildren has more than this many children.")]
    public int MaxChildCount = -1;
    [Tooltip("Change this value if you want ObjectToSet to hide when " +
        "ObjectWithChildren has less than this many children.")]
    public int MinChildCount = -1;


    private void Update()
    {
        if (MaxChildCount != -1)
            CheckMaxChildren();

        if (MinChildCount != -1)
            CheckMinChildren();
    }


    public void CheckMaxChildren()
    {
        if (ObjectWithChildren.childCount > MaxChildCount)
            ObjectToSet.SetActive(false);
        else
            ObjectToSet.SetActive(true);
    }


    public void CheckMinChildren()
    {
        if (ObjectWithChildren.childCount < MinChildCount)
            ObjectToSet.SetActive(false);
        else
            ObjectToSet.SetActive(true);
    }
}
