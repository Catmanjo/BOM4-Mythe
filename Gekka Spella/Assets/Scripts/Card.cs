using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

[CreateAssetMenu(fileName = "Card", menuName = "New Card")]
public class Card : ScriptableObject
{
    public int Id;
    public string Name;
    public int Health;
    public int Power;
    public Sprite Image;



    public Card()
    {

    }
    public Card(int id, string name, int health, int power, Sprite image)
    {
        this.Id = id;
        this.Name = name;
        this.Health = health;
        this.Power = power;
        this.Image = image;
    }
}
