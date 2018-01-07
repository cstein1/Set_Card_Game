using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {
    
    private List<GameObject> board;
    private List<Card> livedeck;
    private GameObject card;
    private bool testing = false;
    private int rand = 0;

    private void Awake()
    {

        card = Instantiate(Resources.Load("Prefabs/PrefCard") as GameObject);

        livedeck = Deck.deck;
        board = new List<GameObject>(12);
        
        for (int i = 0; i < 12; i++)
        {
            board.Add(null);
        }
    }

    // Use this for initialization
    void Start () {
        
		for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
                board[i + 3 * j] = Instantiate(card,
                    new Vector2(
                     map(i,0,2, -a.x*6/8, a.x*6/8),
                     map(j,0,3, -a.y*6/8, a.y*6/8)
                     ), Quaternion.identity);
                board[i + 3 * j].name = "Card" + (i + 3 * j);

                if (testing)
                {
                    rand += 1;
                }
                else
                {
                    rand = Random.Range(0, livedeck.Count);
                }
                board[i + 3 * j].GetComponent<Card>().setCard(livedeck[rand]);

                livedeck.RemoveAt(rand);
            }
        }
        Destroy(card);
	}

    public void RefreshCard(int ind, int newcard) {
        board[ind].GetComponent<Card>().setCard(livedeck[newcard]);
        livedeck.RemoveAt(newcard);
        board[ind].GetComponent<Card>().RefreshVisual();
    }

    public void RefillBoard(Card card1, Card card2, Card card3)
    {
        int ind1 = IndexOfCard(card1);
        int ind2 = IndexOfCard(card2);
        int ind3 = IndexOfCard(card3);
        if (testing)
        {
            if (rand < 81)
            {
                rand += 1;
                RefreshCard(ind1, rand);
            }
            if (rand < 81)
            {
                rand += 1;
                RefreshCard(ind2, rand);
            }
            if (rand < 81)
            {
                rand += 1;
                RefreshCard(ind3, rand);
            }
        } else
        {            
            if (rand < 81)
            {
                rand = Random.Range(0, livedeck.Count);
                RefreshCard(ind1, rand);
            }
            if (rand < 81)
            {
                rand = Random.Range(0, livedeck.Count);
                RefreshCard(ind2, rand);
            }
            if (rand < 81)
            {
                rand = Random.Range(0, livedeck.Count);
                RefreshCard(ind3, rand);
            }
        }
        
        
    }

    public int IndexOfCard(Card crd)
    {
        bool found = false;
        for (int i = 0; i < board.Count && !found; i++)
        {
            Card tmp = board[i].GetComponent<Card>();
            found = tmp.col == crd.col && tmp.num == crd.num && tmp.shape == crd.shape && tmp.fill == crd.fill;
            if (found)
            {
                return i;
            }
        }
        return -1;
    } 

    // Update is called once per frame
    void Update () {
		
	}

    static private float map(float value,
                              float istart,
                              float istop,
                              float ostart,
                              float ostop)
    {
        return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
    }
}
