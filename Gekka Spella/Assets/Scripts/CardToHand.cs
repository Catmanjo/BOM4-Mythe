using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject HandCard;

    // Update is called once per frame
    private void Start()
    {
        CardtoHand();
    }
    void Update()
    {
    }
    public void CardtoHand()
    {
        Hand = GameObject.Find("Hand");
        HandCard.transform.SetParent(Hand.transform);
        HandCard.transform.localScale = Vector3.one;
        HandCard.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        HandCard.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
