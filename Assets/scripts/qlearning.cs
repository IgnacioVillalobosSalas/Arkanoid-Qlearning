using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qlearning : MonoBehaviour {

    public Racket racket;
    public Ball ball;
    private bool entrenando = true;

    private float[,] Rtable;
    private float[,] Qtable;
	// Use this for initialization
	void Start () {

        Rtable = new float[140,3];
        Qtable = new float[140, 3];

        for (int i = 0; i < 140; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Rtable[i, j] = -1;
            }
        }
        for (int i = 0; i < 140; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Qtable[i, j] = 0;
            }
        }
        

        for (int i = 0; i < 6; i++)
        {
            Rtable[i,0] = -10;
            Rtable[i, 1] = -10;
            Rtable[i, 2] = -10;
        }
        for(int i = 84; i < 120; i++)
        {
            Rtable[i, 0] = 1;
            Rtable[i, 1] = 1;
            Rtable[i, 2] = 1;
        }

       
    }
	
	// Update is called once per frame
	void Update () {

   
        if (entrenando)
        {
            updateQtable();
        }else
        {
            useQtable();
        }
	}

    public void toggleentrenamiento()
    {
        if (entrenando)
        {
            entrenando = false;
            Debug.Log("Deja de entrenar");
        }
        else
        {
            entrenando = true;
            Debug.Log("Esta entrenando");
        }
        
    }
    private void updateQtable()
    {
        int row = wichrow(ball.currentstate());
        int bestchoice = bestindex(row);
        Debug.Log(bestchoice);
        if (bestchoice.Equals(2))
            racket.move(-1);
        else
            racket.move(bestchoice);
        Qtable[row, bestchoice] += Rtable[row, bestchoice] + (float)0.1 * Mathf.Max(Qtable[row + 1%140, 0], Qtable[row + 1%140, 1], Qtable[row + 1 % 140, 2]);

    }
    private void useQtable()
    {
        int row = wichrow(ball.currentstate());
        int bestchoice = bestindex(row);
        Debug.Log(bestchoice);
        if (bestchoice.Equals(2))
            racket.move(-1);
        else
            racket.move(bestchoice);
    }
    private int bestindex(int rowtable)
    {
        
        float max = Mathf.Max(Qtable[rowtable, 0],Qtable[rowtable,1],Qtable[rowtable, 2]);
        if (max.Equals(Qtable[rowtable, 0])) return 0;
        if (max.Equals(Qtable[rowtable, 1])) return 1;
        return 2;
    }
    private int wichrow(int[] state)
    {
        //Debug.Log(state[0] + " " + state[1]);
        int row = 0;
        for(int i = 0; i < state[1]; i++)
        {
            row = row + 6;
        }
        for(int i = 0; i < state[0]; i++)
        {
            row++;
        }


        return row;
    }
}
