using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour{

    public List<Card> m_oDeck = new List<Card>();
    public int m_nValueMax = 13;
    public int m_nSuitMax = 4;

    #region Mono Functions
    private void Start() {
        vCreateDeck();
        vShuffleDeck();
    }
    #endregion

    #region Create
    private void vCreateDeck() {
        for (int i = 0; i < m_nSuitMax; i++) {
            for (int j = 0; j < m_nValueMax; j++) {
                Card card = new Card();
                card.suit = (Card.CardSuit)i;
                card.value = (Card.CardValue)j;
                card.name = ((Card.CardValue)j).ToString() + "_" + ((Card.CardSuit)i).ToString();
                m_oDeck.Add(card);
            }
        }
    }
    #endregion

    #region Shuffle
    public void vShuffleDeck() {
        for (int i = 0; i < m_oDeck.Count; i++) {
            Card tempCard = m_oDeck[i];
            int index = UnityEngine.Random.Range(0, m_oDeck.Count);
            m_oDeck[i] = m_oDeck[index];
            m_oDeck[index] = tempCard;
        }
    }
    #endregion

}
