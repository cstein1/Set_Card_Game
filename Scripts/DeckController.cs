using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour {
    public Card tmp; // = Instantiate(Card, new Vector2(-1000,-1000),Quaternion.identity);

    // Use this for initialization
    void Awake () {
        for(int i = 0; i < 3*3*3*3; i++)
        {
            Deck.deck.Add(null);
        }

        TextAsset gameMap = Resources.Load("Text/FullDeck") as TextAsset;
        string[] lines = gameMap.text.Split('\n');

        for(int i = 0; i < 81; i++)
        {
            tmp = gameObject.AddComponent<Card>();
            tmp.col = System.Int32.Parse(lines[i][0].ToString());
            tmp.fill = System.Int32.Parse(lines[i][2].ToString());
            tmp.shape = System.Int32.Parse(lines[i][4].ToString());
            tmp.num = System.Int32.Parse(lines[i][6].ToString());
            tmp.face = "Sprites/set_cards";

            Deck.deck[i] = tmp;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
