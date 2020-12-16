using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvanceRandom;
//using AdvanceRandom.
/*
 * 修改于2020/12/16 14:49
 * 装哥
 * 修改随机数算法
 * 添加平均算法 正态分布算法
 */

public class DiceRolling 
{
    /// <summary>
    /// 返回一个随机整数，范围在1和传入的数值之间（包含1和所传入的数）
    /// </summary>
    private static int BaseRolling(int maxNum)
    {
        int num = AdvanceRandom.Random.AverageRandom(1, maxNum);
        return num;
    }

    /// <summary>
    /// 传入整数n，返回一个n面骰的掷骰结果
    /// </summary>
    /// <param name="numberOfFace"></param>
    /// <returns></returns>
    public static int OneDiceRolling(int numberOfFace)
    {
        if (numberOfFace < 1)
        {
            Debug.LogError("骰子的面数应为正整数");
            return 0;
        }
        int pip = BaseRolling(numberOfFace);
        return pip;
    }
    public static int OneDiceRolling(int numberOfFace,int addition)
    {
        return (OneDiceRolling(numberOfFace) + addition);
    }

    /// <summary>
    /// 传入两个整数，依次为骰子数量n和骰子面数m，返回nDm的结果
    /// </summary>
    /// <param name="numberOfDice"></param>
    /// <param name="numberOfFace"></param>
    /// <returns></returns>
    public static int MultiDicesRolling(int numberOfDice,int numberOfFace)
    {
        if (numberOfDice < 1)
        {
            Debug.LogError("骰子的数量应为正整数");
            return 0;
        }
        int sum = 0;
        for(int i = 0; i < numberOfDice; i++)
        {
            sum += OneDiceRolling(numberOfFace);
        }
        return sum;
    }

    public static int MultiDicesRolling(int numberOfDice, int numberOfFace,int addition)
    {
        return (MultiDicesRolling(numberOfDice, numberOfFace) + addition);
    }

    /// <summary>
    /// 传入两个整数，依次为补正值与难度值，骰D20检定。检定成功返回true，失败false。
    /// </summary>
    /// <param name="bonus"></param>
    /// <param name="difficult"></param>
    /// <returns></returns>
    public static bool Check(int bonus,int difficult)
    {
        int pip = OneDiceRolling(20);
        if (pip + bonus >= difficult)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 传入两个整数，依次为补正值与难度值，骰D20检定。检定失败返回1，成功返回2，大成功返回3，大失败返回0
    /// </summary>
    /// <param name="bonus"></param>
    /// <param name="difficult"></param>
    /// <returns></returns>
    public static int CheckPlus(int bonus,int difficult)
    {
        int res = -1;
        int pip = OneDiceRolling(20);
        if (pip + bonus >= difficult)
        {
            res = 2;
            if (pip == 20)
            {
                res = 3;
            }
        }
        else
        {
            res = 1;
            if (pip == 1)
            {
                res = 0;
            }
        }
        return res;
    }

    /// <summary>
    /// 传入任意个整数，每个整数n对应骰一次n面骰，返回所有点数总和
    /// </summary>
    /// <param name="vs"></param>
    /// <returns></returns>
    public static int VaryDiceRolling(params int[] vs)
    {
        int sum = 0;
        for(int i = 0; i < vs.Length; i++)
        {
            sum += OneDiceRolling(vs[i]);
        }
        return sum;
    }

    /// <summary>
    /// 传入偶数个正整数，每次取两个数n和m，骰nDm，返回总和。
    /// </summary>
    /// <param name="vs"></param>
    /// <returns></returns>
    //public static int PairdVaryDiceRolling(params int[] vs)
    //{
    //    if (vs.Length % 2 == 1)
    //    {
    //        Debug.LogError("应当传入偶数个正整数");
    //        return 0;
    //    }
    //    int sum = 0;
    //    int numOfDice = 0;
    //    for (int i = 0; i < vs.Length; i++)
    //    {
    //        if (i % 2 == 0)
    //        {
    //            numOfDice = vs[i];
    //        }
    //        else
    //        {
    //            sum += (numOfDice * vs[i]);
    //        }
    //    }
    //    return sum;
    //}

}
