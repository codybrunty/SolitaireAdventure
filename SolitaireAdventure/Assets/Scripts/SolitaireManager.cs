using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolitaireManager : MonoBehaviour{

    [Header("Deck")]
    public List<SolitaireCard> m_oAllCards = new List<SolitaireCard>();

    [Header("Solitaire Gameboard")]
    public Transform m_oDeckPosition;
    public List<SolitaireCard> m_oDeck = new List<SolitaireCard>();

    public List<SolitaireCard> m_oPlayingField_0 = new List<SolitaireCard>();
    public Transform m_oPlayingFieldPosition_0;
    public List<SolitaireCard> m_oPlayingField_1 = new List<SolitaireCard>();
    public Transform m_oPlayingFieldPosition_1;
    public List<SolitaireCard> m_oPlayingField_2 = new List<SolitaireCard>();
    public Transform m_oPlayingFieldPosition_2;
    public List<SolitaireCard> m_oPlayingField_3 = new List<SolitaireCard>();
    public Transform m_oPlayingFieldPosition_3;
    public List<SolitaireCard> m_oPlayingField_4 = new List<SolitaireCard>();
    public Transform m_oPlayingFieldPosition_4;
    public List<SolitaireCard> m_oPlayingField_5 = new List<SolitaireCard>();
    public Transform m_oPlayingFieldPosition_5;
    public List<SolitaireCard> m_oPlayingField_6 = new List<SolitaireCard>();
    public Transform m_oPlayingFieldPosition_6;

    #region Mono Functions
    private void Start() {
        vResetGame();
    }
    #endregion

    #region Restart Game

    public void vResetGame() {
        vClearCardLists();
        vShuffleAllCards();
        vMoveAllCardsToDeck();
        vDealCardsIntoPlay();
        vSetCardSortingOrders();
        vAdjustCardPosition();
    }

    private void vMoveAllCardsToDeck() {
        for (int i = 0; i < m_oAllCards.Count; i++) {
            vMoveCard(m_oAllCards[i], m_oDeck, m_oDeckPosition);
            m_oAllCards[i].isHidden = true;
            m_oAllCards[i].vUpdateSolitaireCard();
        }
    }

    public void vDealCardsIntoPlay() {
        List<List<SolitaireCard>> playingfields = new List<List<SolitaireCard>>() { m_oPlayingField_0, m_oPlayingField_1, m_oPlayingField_2, m_oPlayingField_3, m_oPlayingField_4, m_oPlayingField_5, m_oPlayingField_6 };
        List<Transform> playingfieldsPositions = new List<Transform>() { m_oPlayingFieldPosition_0, m_oPlayingFieldPosition_1, m_oPlayingFieldPosition_2, m_oPlayingFieldPosition_3, m_oPlayingFieldPosition_4, m_oPlayingFieldPosition_5, m_oPlayingFieldPosition_6 };
        for (int i = 0; i < 7; i++) {
            int counter = i;
            while (counter<7) {
                SolitaireCard card = vGetNextCardFromDeck();
                vMoveCard(card, playingfields[counter], playingfieldsPositions[counter]);
                if (counter == i) {
                    card.isHidden = false;
                    card.vUpdateSolitaireCard();
                }
                counter++;
            }
        }

    }


    public void vMoveCard(SolitaireCard card, List<SolitaireCard> lst, Transform newPos) {
        vRemoveCardFromAllLists(card);
        lst.Insert(0,card);
        card.transform.position = newPos.position;
        card.transform.SetParent(newPos.transform);
    }

    public void vRemoveCardFromAllLists(SolitaireCard card) {
        m_oDeck.Remove(card);
        m_oPlayingField_0.Remove(card);
        m_oPlayingField_1.Remove(card);
        m_oPlayingField_2.Remove(card);
        m_oPlayingField_3.Remove(card);
        m_oPlayingField_4.Remove(card);
        m_oPlayingField_5.Remove(card);
        m_oPlayingField_6.Remove(card);
    }

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

    #region Clear Card Lists
    private void vClearCardLists() {
        m_oDeck.Clear();
        m_oPlayingField_0.Clear();
        m_oPlayingField_1.Clear();
        m_oPlayingField_2.Clear();
        m_oPlayingField_3.Clear();
        m_oPlayingField_4.Clear();
        m_oPlayingField_5.Clear();
        m_oPlayingField_6.Clear();
    }
    #endregion

    #endregion

    #region Get Next Card From Deal

    public SolitaireCard vGetNextCardFromDeck() {
        SolitaireCard card = m_oDeck[0];
        m_oDeck.RemoveAt(0);
        return card;
    }
#endregion

    #region Set Sorting Order
    public void vSetCardSortingOrders() {
        vSortList(m_oDeck);
        vSortList(m_oPlayingField_0);
        vSortList(m_oPlayingField_1);
        vSortList(m_oPlayingField_2);
        vSortList(m_oPlayingField_3);
        vSortList(m_oPlayingField_4);
        vSortList(m_oPlayingField_5);
        vSortList(m_oPlayingField_6);
    }

    private void vSortList(List<SolitaireCard> lst) {
        int maxSortingOrderNumber = lst.Count;
        
        for (int i = 0; i < lst.Count; i++) {
            lst[i].m_oMainSpriteRenderer.sortingOrder = maxSortingOrderNumber;
            maxSortingOrderNumber--;
        }
    }
    #endregion

    #region Adjust Card Display Positions
    public void vAdjustCardPosition() {
        vAdjustPositions(m_oPlayingField_0);
        vAdjustPositions(m_oPlayingField_1);
        vAdjustPositions(m_oPlayingField_2);
        vAdjustPositions(m_oPlayingField_3);
        vAdjustPositions(m_oPlayingField_4);
        vAdjustPositions(m_oPlayingField_5);
        vAdjustPositions(m_oPlayingField_6);
    }
    private void vAdjustPositions(List<SolitaireCard> lst) {
        float adjustedY = 0f;
        float increment = -.25f;

        for (int i = lst.Count-1; i >= 0; i--) {
            lst[i].transform.position += new Vector3(0f, adjustedY, 0f);
            adjustedY += increment;
        }
    }
    #endregion

}
