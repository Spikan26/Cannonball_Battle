using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    public GameObject targetMovePlayer;

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        //Debug.Log("Swipe in Direction: " + data.Direction);
        targetMovePlayer.GetComponent<PlayerTargetMoveScript>().MobileInput(data);
    }
}
