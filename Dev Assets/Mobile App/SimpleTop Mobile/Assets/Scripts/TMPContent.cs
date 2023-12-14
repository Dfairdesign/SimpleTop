/*******************************************************************************
File: TMPContent.cs
Author: Dylan Fair
Date: 12/8/2023

Description:
    Does Stuff
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPContent : MonoBehaviour
{
    [TextArea]
    public string Content;

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = Content;
    }
}
