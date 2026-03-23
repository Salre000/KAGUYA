using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusRank 
{
    public enum StatusRankRate 
    {
        None=0,
        G=200,
        C=500,
        B=1200,
        A=1800,
        S=2200,
        X=2800
    }

    public static string GetRankText(int value) 
    {
        if ((int)StatusRankRate.G > value) return StatusRankRate.G.ToString();
        if ((int)StatusRankRate.C > value) return StatusRankRate.C.ToString();
        if ((int)StatusRankRate.B > value) return StatusRankRate.B.ToString();
        if ((int)StatusRankRate.A > value) return StatusRankRate.A.ToString();
        if ((int)StatusRankRate.S > value) return StatusRankRate.S.ToString();
        if ((int)StatusRankRate.X > value) return StatusRankRate.X.ToString();

        return "ERROR";

    }

    public static int GetRankMaxValue(int value) 
    {
        if ((int)StatusRankRate.G > value) return (int)StatusRankRate.G;
        if ((int)StatusRankRate.C > value) return (int)StatusRankRate.C;
        if ((int)StatusRankRate.B > value) return (int)StatusRankRate.B;
        if ((int)StatusRankRate.A > value) return (int)StatusRankRate.A;
        if ((int)StatusRankRate.S > value) return (int)StatusRankRate.S;
        if ((int)StatusRankRate.X > value) return (int)StatusRankRate.X;

        return -1;

    }
    public static StatusRankRate GetRank(int value) 
    {
        if ((int)StatusRankRate.G > value) return StatusRankRate.G;
        if ((int)StatusRankRate.C > value) return StatusRankRate.C;
        if ((int)StatusRankRate.B > value) return StatusRankRate.B;
        if ((int)StatusRankRate.A > value) return StatusRankRate.A;
        if ((int)StatusRankRate.S > value) return StatusRankRate.S;
        if ((int)StatusRankRate.X > value) return StatusRankRate.X;

        return StatusRankRate.None;

    }
    public static StatusRankRate GetDownRank(int value) 
    {
        if ((int)StatusRankRate.G > value) return StatusRankRate.None;
        if ((int)StatusRankRate.C > value) return StatusRankRate.G;
        if ((int)StatusRankRate.B > value) return StatusRankRate.C;
        if ((int)StatusRankRate.A > value) return StatusRankRate.B;
        if ((int)StatusRankRate.S > value) return StatusRankRate.A;
        if ((int)StatusRankRate.X > value) return StatusRankRate.S;

        return StatusRankRate.None;

    }






}
