using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeckTester : MonoBehaviour
{
    [SerializeField]
    List<AbilityCardData> _abilityDeckConfig
        = new List<AbilityCardData>();

    [SerializeField] AbilityCardView _abilityCardView1 = null;
    [SerializeField] AbilityCardView _abilityCardView2 = null;
    [SerializeField] AbilityCardView _abilityCardView3 = null;

    [SerializeField] Image _handCard1 = null;
    [SerializeField] Image _handCard2 = null;
    [SerializeField] Image _handCard3 = null;

    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();

    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    private int handMax = 2; 

    private void Start()
    {
        SetupAbilityDeck();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }

        
        if(_playerHand.LastIndex == 0)
        {
            //if player is holding 1 card, show that card
            _handCard1.gameObject.SetActive(true);
            _handCard2.gameObject.SetActive(false);
            _handCard3.gameObject.SetActive(false);
            _abilityCardView1.Display(_playerHand.GetCard(_playerHand.LastIndex));
        }
        else if (_playerHand.LastIndex == 1)
        {
            //if player is holding 2 cards, show both cards
            _handCard1.gameObject.SetActive(true);
            _handCard2.gameObject.SetActive(true);
            _handCard3.gameObject.SetActive(false);

            _abilityCardView1.Display(_playerHand.GetCard(_playerHand.LastIndex));
            _abilityCardView2.Display(_playerHand.GetCard(_playerHand.LastIndex - 1));
        } 
        else if (_playerHand.LastIndex == 2)
        {
            //if player is holding 3 cards, show all cards
            _handCard1.gameObject.SetActive(true);
            _handCard2.gameObject.SetActive(true);
            _handCard3.gameObject.SetActive(true);

            _abilityCardView1.Display(_playerHand.GetCard(_playerHand.LastIndex));
            _abilityCardView2.Display(_playerHand.GetCard(_playerHand.LastIndex - 1));
            _abilityCardView3.Display(_playerHand.GetCard(_playerHand.LastIndex - 2));
        } 
    }

    private void SetupAbilityDeck()
    {
        foreach(AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }

        _abilityDeck.Shuffle();
    }

    public void Draw()
    {
        if(_playerHand.LastIndex < handMax)
        {
            AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
            Debug.Log("Drew card: " + newCard.Name);
            _playerHand.Add(newCard, DeckPosition.Top);
            // _abilityCardView.Display(newCard);
        }
    }

    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    public void PlayTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding REmove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }

    public void DiscardTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }

    public void ReshuffleDiscarded()
    {
        for(int i = 0; i <= _abilityDiscard.LastIndex; i++)
        {
            AbilityCard targetCard = _abilityDiscard.TopItem;
            //TODO consider expanding REmove to accept a deck position
            _abilityDiscard.Remove(_abilityDiscard.LastIndex);
            _abilityDeck.Add(targetCard);
        }

        _abilityDeck.Shuffle();
        Debug.Log("Discard pile shuffled back into ability deck.");
    }
}
