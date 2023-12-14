/*******************************************************************************
File: PanelSwiper.cs
Author: Dylan Fair
DP Email: dylan.fair@digipen.edu
Date: 12/11/2023
Course: CS176
Section: B

Description:
    Facilitates swiping between multiple panels, left to right. 
If the user swipes left from the leftmost panel, this goes to the rightmost
 panel, but if they swipe right from the rightmost panel, it goes to the leftmost

*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    //Getters & Setters
    int _CurrentPanel = 0;
    public int CurrentPanel
    {
        get => _CurrentPanel;

        set
        {
            //If swiping left of the first panel, wrap to the last panel
            if (value < 0)
                value = PanelLocations.Count - 1;

            //If swiping right of the last panel, wrap to the first panel
            if (value >= PanelLocations.Count)
                value = 0;

            _CurrentPanel = value;
        }
    }

    //public variables
    [Range(0f, 1f)]
    public float PercentThreshold = 0.2f;
    public float TransTime = .25f;

    //private variables
    Vector3 CurrentPanelLoc;
    List <Vector3>PanelLocations = new List<Vector3>();


    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            PanelLocations.Add(transform.GetChild(i).localPosition);
            
        CurrentPanel = 0;
    }


    private void Update()
    {
        
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        float diff = eventData.pressPosition.x - eventData.position.x;
        transform.localPosition = CurrentPanelLoc - new Vector3(diff, 0, 0);
    }


    //TODO: Reference children positions instead of Screen.width
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //Create variables for the percent of the screen dragged and the location to move to
        float percent = (eventData.pressPosition.x - eventData.position.x) / Screen.width;
        Vector3 newLoc = CurrentPanelLoc;

        //if user doesn't drag enough to turn the page, return to last location
        if (Mathf.Abs(percent) < PercentThreshold)
        {
            StartCoroutine(SmoothTransition(transform.localPosition, CurrentPanelLoc, TransTime));
            transform.localPosition = CurrentPanelLoc;
            return;
        }

        //Change new location based on drag direction
        if (percent < 0)
            CurrentPanel--;
        else if (percent > 0)
            CurrentPanel++;

        //Invert Vec3 to swipe the opposite direction drag goes
        newLoc = -PanelLocations[CurrentPanel];

        StartCoroutine(SmoothTransition(CurrentPanelLoc, newLoc, TransTime));
    }


    IEnumerator SmoothTransition (Vector3 startPos, Vector3 endPos, float seconds)
    {
        float t = 0f;

        while (t <= 1)
        {
            t += Time.deltaTime / seconds;

            transform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
            CurrentPanelLoc = transform.localPosition;

            yield return null;
        }
    }
}