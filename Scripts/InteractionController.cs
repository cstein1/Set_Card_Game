using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {

    public List<Card> selected;

    public bool AddCard(Card card)
    {
        if (selected.Count <= 2)
        {
            selected.Add(card);
            if (selected.Count == 3)
            {
                if (Check())
                {
                    GameObject.Find("GameBoard").GetComponent<BoardController>().RefillBoard(selected[2],selected[1],selected[0]);
                    RemoveCard(selected[2]);
                    RemoveCard(selected[1]);
                    RemoveCard(selected[0]);
                }
            }
            return true;
        }
        else return false;

    }

    public bool RemoveCard(Card card)
    {
        return selected.Remove(card);       
    }

    public bool Check()
    {
        // WE DID NOT SET THIS UP RIGHT. OMG
        bool match = true;
        match &= selected[0].col == selected[1].col && selected[2].col == selected[1].col ||
            selected[0].col != selected[1].col && selected[1].col != selected[2].col && selected[0].col != selected[2].col;
        match &= selected[0].num == selected[1].num && selected[2].num == selected[1].num ||
                        selected[0].num != selected[1].num && selected[1].num != selected[2].num && selected[0].num != selected[2].num;
        match &= selected[0].shape == selected[1].shape && selected[2].shape == selected[1].shape ||
                        selected[0].shape != selected[1].shape && selected[1].shape != selected[2].shape && selected[0].shape != selected[2].shape;
        match &= selected[0].fill == selected[1].fill && selected[2].fill == selected[1].fill ||
                        selected[0].fill != selected[1].fill && selected[1].fill != selected[2].fill && selected[0].fill != selected[2].fill;
        return match;
    }

	// Use this for initialization
	void Start () {
        selected = new List<Card>(3);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
