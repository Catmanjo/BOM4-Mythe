using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    internal List<GameObject> EnemyCardsinHand= new List<GameObject>();
    internal List<GameObject> EnemyCardsinRanged = new List<GameObject>();
    internal List<GameObject> EnemyCardsinMelee = new List<GameObject>();

    [SerializeField]private int numberofactions;

    private GameObject movedrangecard;
    private GameObject movedmeleecard;
    private GameObject chosencard;

    [SerializeField]private GameObject enemyrange1;
    [SerializeField]private GameObject enemyrange2;
    [SerializeField]private GameObject enemymelee1;
    [SerializeField]private GameObject enemymelee2;
    [SerializeField]private GameObject enemymelee3;
    [SerializeField]private GameObject enemygrave;
    [SerializeField]private GameObject enemydeck;
    [SerializeField]private GameObject Turnsystem;

    private TurnSystem turn;
    private EnemyDeck deck;
    private Draggable drag;

    // Start is called before the first frame update
    void Start()
    {
        turn = Turnsystem.GetComponent<TurnSystem>();
        deck = enemydeck.GetComponent<EnemyDeck>();

        TurnSystem.OnEndTurn += handleOnEndTurn;
    }

    private void ChooseRangeCard()
    {
        if (EnemyCardsinHand.Count > 0)
        {
            if (EnemyCardsinHand[0] != null)
            {
                chosencard = EnemyCardsinHand[0];
                EnemyCardsinHand.RemoveAt(0);
                movedrangecard = chosencard;
                drag = movedrangecard.GetComponent<Draggable>();
            }
            else
            {
                deck.DrawCard(0);
                Debug.Log("issue in the skill");
            }
        }
    }
    private void MoveCardToRange()
    {
        int random = Randomizer(1, 6);
        //bool below3;
        
        /*if (random < 3)
        {
            below3 = true;
        } else if (random > 3)
        {
            below3 = false;
        }*/
        if (random < 3 && enemyrange1.transform.childCount == 0)
        {
            movedrangecard.transform.SetParent(enemyrange1.transform);
            movedrangecard.transform.localPosition = new Vector3(0,0,0);
            movedrangecard.GetComponent<Cardback>().TurnCard(false);
            movedrangecard.transform.tag = "EnemyRangeCard1";
            EnemyCardsinRanged.Add(movedrangecard);
            Debug.Log("range1");
        }
        else if ((random > 3  /*below3 == true*/) && enemyrange2.transform.childCount == 0)
        {
            movedrangecard.transform.SetParent(enemyrange2.transform);
            movedrangecard.transform.localPosition = new Vector3(0, 0, 0);
            movedrangecard.GetComponent<Cardback>().TurnCard(false);
            movedrangecard.transform.tag = "EnemyRangeCard2";
            EnemyCardsinRanged.Add(movedrangecard);
            Debug.Log("range2");
        }
        else
        {
            movedrangecard.transform.SetParent(enemygrave.transform);
            movedrangecard.transform.localPosition = new Vector3(0, 0, 0);
            Debug.Log("skill issue");
        }
    }

    private void ChooseMeleeCard() // Chooses a Range card to move to Melee
    {
        int number = Randomizer(1, 2);
        int number2 = Randomizer(1, 2);
        int spot1 = 0;
        int spot2 = 1;
        
        
        if (EnemyCardsinRanged != null && EnemyCardsinRanged.Count > 0)
        {
            if (number == 1 && drag.turnsexisted == 1)
            {
                chosencard = EnemyCardsinRanged[spot1];
                EnemyCardsinRanged.RemoveAt(spot1);
                movedmeleecard = chosencard;
                drag = movedmeleecard.GetComponent<Draggable>();
            } else if (number == 2 && drag.turnsexisted == 1)
            {
                chosencard = EnemyCardsinRanged[spot2];
                EnemyCardsinRanged.RemoveAt(spot2);
                movedmeleecard = chosencard;
                drag = movedmeleecard.GetComponent<Draggable>();
            }
        } 
        else 
        {
            if (number2 == 1 && EnemyCardsinHand != null)
            {
                ChooseRangeCard();
                MoveCardToRange();
            }
            else if (number2 == 2 && EnemyCardsinHand.Count < 7)
            {
                deck.DrawCard(0);
            }
        }
    }
    private void MoveCardToMelee() // Moves the chosen card to Melee
    {
        int number = Randomizer(1, 6);
        //bool under4;
       /* if (number < 4)
        {
            under4 = false;
        }
        else if (number > 4)
        {
            under4 = true;
        }*/
        if (number < 2 && enemymelee1.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee1.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            movedmeleecard.GetComponent<Cardback>().TurnCard(false);
            movedmeleecard.transform.tag = "EnemyMeleeCard1";
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee1");
        }
        else if ((number > 2  /*under4 == true*/) && number < 4 && enemymelee2.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee2.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            movedmeleecard.GetComponent<Cardback>().TurnCard(false);
            movedmeleecard.transform.tag = "EnemyMeleeCard2";
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee2");
        }
        else if (number > 4 && enemymelee3.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee3.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            movedmeleecard.GetComponent<Cardback>().TurnCard(false);
            movedmeleecard.transform.tag = "EnemyMeleeCard3";
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee3");
        }
        else
        {
            movedmeleecard.transform.SetParent(enemygrave.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            Debug.Log("skill issue");
        }
    }
    private int Randomizer(int Min, int Max)
    {
        int number = UnityEngine.Random.Range(Min, Max);
        return number;
    }

    IEnumerator AIBehaviour()
    {
        for (int i = 0; i < numberofactions; i++)
        {
            int number = Randomizer(1, 4);
            yield return new WaitForSeconds(2);
            if (EnemyCardsinRanged.Count == 0)
            {
                ChooseRangeCard();
                if (movedrangecard != null)
                {
                    MoveCardToRange();
                }
                else
                {
                    deck.DrawCard(0);
                }
            }
            else {
                ChooseMeleeCard();
                if (movedmeleecard != null)
                {
                    MoveCardToMelee();
                }
                else
                {
                    deck.DrawCard(0);
                }
            } 
        }
        turn.EndyourOponentTurn();
    }

    void handleOnEndTurn() 
    {
        if (turn.isYourTurn == false)
        {
            StartCoroutine(AIBehaviour());
        }
        else if (turn.isYourTurn == true)
        {
            StopCoroutine(AIBehaviour());
        }
    }
}
