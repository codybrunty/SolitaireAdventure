using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card {

    public string name;

    public enum CardSuit { Heart, Club, Diamond, Spade }
    public CardSuit suit;
    
    public enum CardValue { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public CardValue value;

}
