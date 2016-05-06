using UnityEngine;
using System.Collections;

namespace NorthmenGoFish {

	public class CardType {

		public CardSuit Suit { get; private set; }
		public CardValue Value { get; private set; }

		public CardType(CardSuit suit, CardValue value) {

			this.Suit = suit;
			this.Value = value;

		}

	}

	public class Card {

		public CardType Type { get; private set; }

		public Card(CardType type) {

			this.Type = type;

		}

	}

	public class Cards {

		public static CardType ACE_HEART = new CardType(CardSuit.Heart, CardValue.Ace);
		public static CardType TWO_HEART = new CardType(CardSuit.Heart, CardValue.Two);
		public static CardType THREE_HEART = new CardType(CardSuit.Heart, CardValue.Three);
		public static CardType FOUR_HEART = new CardType(CardSuit.Heart, CardValue.Four);
		public static CardType FIVE_HEART = new CardType(CardSuit.Heart, CardValue.Five);
		public static CardType SIX_HEART = new CardType(CardSuit.Heart, CardValue.Six);
		public static CardType SEVEN_HEART = new CardType(CardSuit.Heart, CardValue.Seven);
		public static CardType EIGHT_HEART = new CardType(CardSuit.Heart, CardValue.Eight);
		public static CardType NINE_HEART = new CardType(CardSuit.Heart, CardValue.Nine);
		public static CardType TEN_HEART = new CardType(CardSuit.Heart, CardValue.Ten);
		public static CardType JACK_HEART = new CardType(CardSuit.Heart, CardValue.Jack);
		public static CardType QUEEN_HEART = new CardType(CardSuit.Heart, CardValue.Queen);
		public static CardType KING_HEART = new CardType(CardSuit.Heart, CardValue.King);

		public static CardType ACE_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Ace);
		public static CardType TWO_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Two);
		public static CardType THREE_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Three);
		public static CardType FOUR_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Four);
		public static CardType FIVE_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Five);
		public static CardType SIX_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Six);
		public static CardType SEVEN_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Seven);
		public static CardType EIGHT_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Eight);
		public static CardType NINE_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Nine);
		public static CardType TEN_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Ten);
		public static CardType JACK_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Jack);
		public static CardType QUEEN_DIAMOND = new CardType(CardSuit.Diamond, CardValue.Queen);
		public static CardType KING_DIAMOND = new CardType(CardSuit.Diamond, CardValue.King);

		public static CardType ACE_CLUB = new CardType(CardSuit.Club, CardValue.Ace);
		public static CardType TWO_CLUB = new CardType(CardSuit.Club, CardValue.Two);
		public static CardType THREE_CLUB = new CardType(CardSuit.Club, CardValue.Three);
		public static CardType FOUR_CLUB = new CardType(CardSuit.Club, CardValue.Four);
		public static CardType FIVE_CLUB = new CardType(CardSuit.Club, CardValue.Five);
		public static CardType SIX_CLUB = new CardType(CardSuit.Club, CardValue.Six);
		public static CardType SEVEN_CLUB = new CardType(CardSuit.Club, CardValue.Seven);
		public static CardType EIGHT_CLUB = new CardType(CardSuit.Club, CardValue.Eight);
		public static CardType NINE_CLUB = new CardType(CardSuit.Club, CardValue.Nine);
		public static CardType TEN_CLUB = new CardType(CardSuit.Club, CardValue.Ten);
		public static CardType JACK_CLUB = new CardType(CardSuit.Club, CardValue.Jack);
		public static CardType QUEEN_CLUB = new CardType(CardSuit.Club, CardValue.Queen);
		public static CardType KING_CLUB = new CardType(CardSuit.Club, CardValue.King);

		public static CardType ACE_SPADE = new CardType(CardSuit.Spade, CardValue.Ace);
		public static CardType TWO_SPADE = new CardType(CardSuit.Spade, CardValue.Two);
		public static CardType THREE_SPADE = new CardType(CardSuit.Spade, CardValue.Three);
		public static CardType FOUR_SPADE = new CardType(CardSuit.Spade, CardValue.Four);
		public static CardType FIVE_SPADE = new CardType(CardSuit.Spade, CardValue.Five);
		public static CardType SIX_SPADE = new CardType(CardSuit.Spade, CardValue.Six);
		public static CardType SEVEN_SPADE = new CardType(CardSuit.Spade, CardValue.Seven);
		public static CardType EIGHT_SPADE = new CardType(CardSuit.Spade, CardValue.Eight);
		public static CardType NINE_SPADE = new CardType(CardSuit.Spade, CardValue.Nine);
		public static CardType TEN_SPADE = new CardType(CardSuit.Spade, CardValue.Ten);
		public static CardType JACK_SPADE = new CardType(CardSuit.Spade, CardValue.Jack);
		public static CardType QUEEN_SPADE = new CardType(CardSuit.Spade, CardValue.Queen);
		public static CardType KING_SPADE = new CardType(CardSuit.Club, CardValue.King);

		public static CardType[] CARDS = new CardType[] {

			ACE_HEART,
			TWO_HEART,
			THREE_HEART,
			FOUR_HEART,
			FIVE_HEART,
			SIX_HEART,
			SEVEN_HEART,
			EIGHT_HEART,
			NINE_HEART,
			TEN_HEART,
			JACK_HEART,
			QUEEN_HEART,
			KING_HEART,
			ACE_DIAMOND,
			TWO_DIAMOND,
			THREE_DIAMOND,
			FOUR_DIAMOND,
			FIVE_DIAMOND,
			SIX_DIAMOND,
			SEVEN_DIAMOND,
			EIGHT_DIAMOND,
			NINE_DIAMOND,
			TEN_DIAMOND,
			JACK_DIAMOND,
			QUEEN_DIAMOND,
			KING_DIAMOND,
			ACE_CLUB,
			TWO_CLUB,
			THREE_CLUB,
			FOUR_CLUB,
			FIVE_CLUB,
			SIX_CLUB,
			SEVEN_CLUB,
			EIGHT_CLUB,
			NINE_CLUB,
			TEN_CLUB,
			JACK_CLUB,
			QUEEN_CLUB,
			KING_CLUB,
			ACE_SPADE,
			TWO_SPADE,
			THREE_SPADE,
			FOUR_DIAMOND,
			FIVE_DIAMOND,
			SIX_DIAMOND,
			SEVEN_DIAMOND,
			EIGHT_DIAMOND,
			NINE_DIAMOND,
			TEN_DIAMOND,
			JACK_DIAMOND,
			QUEEN_DIAMOND,
			KING_DIAMOND,

		};

	}

	public enum CardSuit {

		Heart,
		Diamond,
		Club,
		Spade

	}

	public enum CardValue {

		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King

	}

}
