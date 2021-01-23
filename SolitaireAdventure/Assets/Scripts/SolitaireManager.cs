using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolitaireManager : MonoBehaviour{

    [Header("Deck")]
    public Transform m_oOutOfPlayPosition;
    public List<SolitaireCard> m_oAllCards = new List<SolitaireCard>();

    [Header("Solitaire Gameboard")]
    public Transform m_oDeckPosition;
    public List<SolitaireCard> m_oDeck = new List<SolitaireCard>();

    #region Mono Functions
    private void Start() {
        vResetGame();
    }
    #endregion

    #region Restart Game

    public void vResetGame() {
        vMoveAllCardsOutOfPlay();
        vClearCardLists();
        vShuffleAllCards();
        vMoveAllCardsToDeck();
        vSetSortingOrders();
    }
    private void vMoveAllCardsOutOfPlay() {
        for (int i = 0; i < m_oAllCards.Count; i++) {
            m_oAllCards[i].transform.position = m_oOutOfPlayPosition.position;
            m_oAllCards[i].transform.SetParent(m_oOutOfPlayPosition);
        }
    }

    private void vClearCardLists() {
        m_oDeck.Clear();
    }

    private void vMoveAllCardsToDeck() {
        for (int i = 0; i < m_oAllCards.Count; i++) {
            m_oDeck.Add(m_oAllCards[i]);
            m_oAllCards[i].transform.position = m_oDeckPosition.position;
            m_oAllCards[i].transform.SetParent(m_oDeckPosition);
            m_oAllCards[i].isHidden = true;
            m_oAllCards[i].vUpdateSolitaireCard();
        }
    }

    #endregion

    #region Set Sorting
    public void vSetSortingOrders() {
        vSortDeck();
    }

    private void vSortDeck() {
        int maxSortingOrderNumber = m_oDeck.Count+1;
        
        for (int i = 0; i < m_oDeck.Count; i++) {
            m_oDeck[i].m_oMainSpriteRenderer.sortingOrder = maxSortingOrderNumber;
            maxSortingOrderNumber--;
        }
    }
    #endregion

    #region Shuffle All Cards
    public void vShuffleAllCards() {
        for (int i = 0; i < m_oAllCards.Count; i++) {
            SolitaireCard tempCard = m_oAllCards[i];
            int index = UnityEngine.Random.Range(0, m_oAllCards.Count);
            m_oAllCards[i] = m_oAllCards[index];
            m_oAllCards[index] = tempCard;
        }
    }
    #endregion

}
