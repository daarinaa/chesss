using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chessman
{
    private MeshRenderer meshRenderer;

    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        Chessman c, c2;

        //White move
        if (isWhite)
        {
            //Diagonal Left
            if (CurrentX != 0 && CurrentY != 7)
            {
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    r[CurrentX - 1, CurrentY + 1] = true;
            }

            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 7)
            {
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    r[CurrentX + 1, CurrentY + 1] = true;
            }

            //Middle
            if (CurrentY != 7)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                    r[CurrentX, CurrentY + 1] = true;
            }

            //Middle on first move
            if (CurrentY == 1)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY + 2] = true;
            }
        }
        else
        {
            //Diagonal Left
            if (CurrentX != 0 && CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    r[CurrentX - 1, CurrentY - 1] = true;
            }

            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    r[CurrentX + 1, CurrentY - 1] = true;
            }

            //Middle
            if (CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                    r[CurrentX, CurrentY - 1] = true;
            }

            //Middle on first move
            if (CurrentY == 6)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY - 2] = true;
            }
        }

        return r;
    }
}
