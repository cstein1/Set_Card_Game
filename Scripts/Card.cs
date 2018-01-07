using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public bool highlighted = false;

    public Light lgt;
    public int col;
    public int num;
    public int shape;
    public int fill;

    public string face;


    public void setCard(Card card)
    {
        col = card.col;
        num = card.num;
        shape = card.shape;
        face = card.face;
        fill = card.fill;

        lgt = this.GetComponent<Light>();
        lgt.range = 3;
        lgt.enabled = false;
    }

    public void RefreshVisual()
    {
        if (face != null)
        {
            lgt.enabled = false;
            //GetComponent<Light>().range = 0;
            highlighted = false;
            this.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>(face)[shape + 3 * col + 9 * num + 27 * fill];
            this.transform.localScale = new Vector3(3, 3, 1);
            
        }
    }

	// Use this for initialization
	void Start () {
        lgt = this.GetComponent<Light>();
        lgt.range = 3;
        lgt.enabled = false;
        RefreshVisual();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        InteractionController inter = GameObject.Find("GameBoard").GetComponent<InteractionController>();
        if (highlighted)
        {
            inter.RemoveCard(this);
            highlighted = false;
            lgt.enabled = false;
            //GetComponent<Light>().range = 0;
        } else if(inter.AddCard(this))
        {
            highlighted = true;
            lgt.enabled = true;
            //lgt.range = 3;
            //GetComponent<Light>().range = 3;
        }
    }
}
