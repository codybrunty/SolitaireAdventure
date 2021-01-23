using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolitaireCard : MonoBehaviour{
    [Header("Card Info")]
    public int m_nSpriteIndex;
    public enum CardSuit { Club, Diamond, Heart, Spade }
    public CardSuit m_oSuit;
    public enum CardValue { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public CardValue m_oValue;

    [Header("Sprite Info")]
    public SpriteRenderer m_oMainSpriteRenderer;
    public Sprite m_oCardFrontSprite;
    public Sprite m_oCardBackSprite;
    public bool isHidden = false;

    public void vUpdateSolitaireCard() {
        if (isHidden) {
            m_oMainSpriteRenderer.sprite = m_oCardBackSprite;
        }
        else {
            m_oMainSpriteRenderer.sprite = m_oCardFrontSprite;
        }
    }

}
