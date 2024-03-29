﻿using System.ComponentModel;
using AoC.Console.Extensions;

namespace AoC.Console._02;

public class A
{
    private const string Input = @"B X
B Z
B Z
A Y
B X
A Y
C Y
A Y
C X
B X
A Y
B Z
A Y
A X
B X
A Y
A Y
B Y
A Y
A Y
A Y
B Y
C Y
A Y
A Y
C X
B Z
B Z
C Z
B Z
A Y
A Y
B Z
A Y
B X
A Y
A Y
A Y
C Z
A Y
C Y
B X
A Y
A Y
A Y
B X
A X
B Y
B Z
A Y
A Y
A Y
B Z
A Y
A Y
B Y
B X
C Y
B Z
C Z
A Y
C X
B Z
A Z
C X
A Y
A Y
A Z
B Z
A Y
A Y
B Y
B Z
A Y
A Y
C X
B X
A Y
B Z
A Y
B Y
B Y
A Y
B Y
B Z
B X
B Y
B X
B Z
B Z
A Y
A Y
A Z
A X
A Y
B Z
A Y
B X
A X
A Y
B X
A X
A Z
B Z
A Y
A Y
A Y
B Z
A Y
B X
A Y
A Y
B Z
B Y
A X
C Y
C Y
A Y
B X
B X
B Z
B Z
B Y
B Y
B Z
B Z
B X
B Z
B Z
B Z
A Y
A Y
B Z
B Z
B X
A Y
C Z
B Z
B X
B Z
A X
A Y
B X
B X
A Y
B X
B Z
B Z
A Z
B Y
A Y
B X
A Y
C Y
B Y
A Y
A Y
B Y
B X
A Y
B X
B Z
A Y
B Z
B X
B X
A Y
A Y
B Z
A Z
B Z
C Z
B Z
C X
A Y
A Y
A Y
A Y
A Y
A Z
B Z
B Y
C Y
A X
C Y
A Y
A X
B Z
A Y
C Z
A Y
A Y
A Z
C Y
C Y
A Y
A Y
A Y
B Z
B Z
B X
B X
B Y
A Y
A X
B Z
B X
B Z
A Y
B Z
A X
B Z
A Y
A Y
B Z
A X
B Y
A Y
A Y
A Y
B X
A Y
C Z
B Y
B X
A Y
B Z
A Y
A Y
A Y
B Z
A Z
C Y
A Y
A Y
B Z
A Y
A Y
A Y
B Z
A Z
A Y
A Y
A Y
A Y
A Y
A Y
B X
A Y
B X
A Y
C Z
B Z
A Y
A Y
B Z
A Y
A Y
B Z
A Y
A Y
A Y
B Z
A Z
A Y
A Y
C Y
A Y
A Y
A Y
B Z
A Y
A Z
B Z
C Y
B Y
B Z
B Z
C X
A Y
A X
B Y
A Y
B Z
A X
B Y
C Y
B Z
A Y
A Y
B X
A Y
B Z
B Z
B X
B Z
A Y
A Y
A Y
A Y
A Y
A Y
B Y
A Y
A Y
A Y
A Y
A Y
B Z
A Y
A Y
A Y
A Y
A Y
B Y
B Y
A Y
A Z
A Y
A Y
A Y
B X
B Z
A X
A Z
A Y
B X
A Z
A Y
B X
A X
B X
A Y
A Y
B X
B X
A Y
B X
A Y
A Y
B Y
B Z
A Y
A Y
B Z
C X
B X
B Z
B Z
A Y
A X
A Y
A Y
C Y
A Y
B Z
C Y
C Y
A Y
A Y
B X
A Y
A Y
A Y
A Y
A X
A Y
B Y
B Z
A Y
B Z
B X
C Y
B Z
B X
B Z
A Y
A Y
A Z
A Y
C Y
B Z
A Y
A Y
B Y
B Z
B Z
A X
A Y
B Z
A Y
B X
A Y
A Y
B Z
B X
B Z
A Y
A Y
B Y
B Z
B X
A Y
B X
A Y
A Y
A Y
A Y
A Y
B Z
A Y
B Y
A Z
B X
B Z
B X
A Y
B X
A Y
B Y
B Y
A Y
C Z
C Y
A Y
B Z
B X
A Y
A Y
A Y
A Y
B Y
B Z
B Z
A Y
A Y
A Y
A Y
B X
A Y
B Y
B Z
A Y
B Z
B Z
B Z
A Y
B Z
B Z
B X
B Z
A Y
B Z
A Y
B X
B Z
A Y
A Y
A Y
C Y
B Z
C Z
A Y
B Z
C Y
A Y
A Y
A Y
B Z
A Y
A Y
B X
B X
A X
A Y
A Y
B X
B X
A X
A Y
A Y
A X
B X
B Y
A Y
A Y
B X
B Z
B X
A Y
B X
B Y
A Y
B Y
B X
A Z
A Y
A Y
B X
A X
A Z
B X
A Y
A X
B X
A Y
A Y
A Y
A Y
A Y
B Y
A Y
B X
B Y
B Z
B Y
A Y
A Y
A Y
A Y
B Y
A Y
A X
B Y
A Y
B Z
A Y
A Z
A Y
A Y
A Y
C Z
A Y
A Y
B X
B X
C Z
A Y
B Z
A X
B X
A Y
B Z
A Y
B Z
A Y
A Y
B Z
A X
A X
B X
B Y
B Z
B Z
C Z
A Y
A X
A Y
C X
A Y
B X
B X
B Z
A Y
A Z
A Y
C Z
B Z
B Y
B Z
C Y
C X
A Y
B X
B Z
A Y
B X
B Y
A Y
A Y
A Y
A Y
B Z
C Y
B Y
C X
A Y
A Y
B Z
C Y
B Z
A Y
A X
A Y
A Y
A Y
A Y
B X
C Y
A Y
A Y
B X
A Y
B X
B Y
C Z
A Y
A Y
A Y
A Y
B Z
B X
C Y
B X
A Y
A Z
C Y
A X
A Y
B Z
B Z
A Y
A Y
C Y
A Y
B X
C Z
B Z
A X
A Y
A Y
B Z
B Z
A Y
B X
B X
B X
A Y
B X
B Z
A Y
A Y
A Y
A Y
C Y
A Y
C Z
A X
B Z
B X
A Y
B X
A Y
B Y
A Y
A Z
A Y
A Y
B Z
B Y
B X
B Z
A Y
A Y
A Y
A Y
A Y
A Y
A Y
A Y
C Z
B Z
B X
A Y
A Z
B Y
A Y
A Y
B Y
A Y
B Y
B X
A Y
A Z
A Y
A Y
A Y
A Y
A Z
A Y
B Z
A Y
A Y
B Z
B Z
A Y
C Z
B X
A Y
C Y
B X
A Y
B X
B Z
B Z
A Y
A Y
A Y
A X
B X
B X
A Y
B Y
B Y
A Y
A X
A Y
B Z
C Y
A Y
C Z
B Z
C Y
B X
A Z
A Y
A Y
A Y
A Y
C X
B X
B X
A Z
B Y
A Y
A Y
B X
A Y
A Y
A X
B X
C Z
B X
C Y
A X
B X
C Y
C X
A Y
A Y
B Y
C Y
A Y
B X
B Z
A X
A Y
B X
B Z
B Z
B X
B Z
B Y
A Y
A Y
A Y
A Y
A Y
A Z
B Y
A X
B X
C Y
A Y
B Y
A Y
B X
A Y
A Y
A Y
A Y
A Y
A Y
B Z
B Z
A Y
A Y
A Y
C Z
A Y
A Y
A Z
B Z
C Y
B Z
A Y
B Z
A X
A Y
B X
B Z
A Y
A Y
A Y
A Y
B X
B Y
C Z
A Y
A Y
A Y
C Z
A X
B Z
B X
C Y
B X
B X
A Y
C Y
B X
A Z
A Y
B X
A Y
A Y
B Z
A Y
A Y
A Y
B Y
A Y
A Y
A Y
A Y
B X
C Y
A Y
A Y
A Y
A Y
A Y
B Z
B X
B Z
A Y
B X
A Y
B X
C Y
A Y
A Y
A Y
C Y
A Z
A Y
A Y
B Y
B Z
B Z
A Y
B X
A Y
B X
C Y
A Y
B X
B X
B X
A Y
B Y
A Y
A Y
B X
B X
A Y
A Y
C Y
A Y
B Z
A Y
A Y
B Z
A Y
C Y
B X
A Y
A Y
A Y
B X
B X
B X
A Y
B Z
B Z
B X
B Z
A Y
B X
B Z
A Y
A Y
C Z
B X
B X
C Z
C Y
A Y
C Z
A Y
A X
B Z
A Y
A Y
A Y
B Z
B Z
B Z
A Y
A Y
B Z
C Y
A Y
A X
B Z
A Y
A Y
B Z
B Z
C Y
C Z
A Y
A X
B Z
C Z
B Y
B X
B X
B X
B Y
B X
A Y
B X
B Z
B Z
A Y
B Z
A Y
A Y
A Y
B X
A Y
A Y
B X
A Y
A Y
A Y
A Y
A Z
B X
A Y
B Z
A Y
A Y
B Z
A Y
A Y
A Y
A X
A Z
A Y
B Y
C Y
A Y
A Y
A Y
C Y
A Y
B X
A Y
B Z
B X
B Z
A Y
B Z
A Z
B X
A Y
A Z
B X
B X
B Z
A Y
A Y
B Z
A Z
A Y
C Y
A Y
A Y
B Z
B Z
B X
C Y
B X
A Y
B X
B Y
B Y
C Z
A Y
A Y
B Z
B X
A Y
A X
A Y
A Z
A Y
B Y
A X
A Y
B Y
A Y
B X
A Y
A Y
A Y
A Y
B Z
A Y
A Y
A Y
B X
A Y
B Y
A Y
A Y
B X
B Y
B X
B Z
A X
A Y
B X
B Z
A Y
B Y
B Y
A X
C Y
B Z
B X
A Y
B Z
A X
B Y
B X
A Y
C Y
B Z
B X
A Y
B Z
C Z
A Y
A Y
A Y
A Y
B X
B X
A X
A Y
A Y
A Y
A X
C Y
C X
B Z
A Y
A Y
B X
A Y
A Y
C Y
B X
A X
B X
C X
A Z
A Y
C Z
A Y
A Y
B Z
B Z
C Y
A Y
A Y
B X
B X
A Y
C X
A X
A Y
A Y
A Y
B Y
A Y
A Y
B X
A Y
B Z
C X
A Y
B X
A Y
A X
A Y
A X
B X
A Y
A Y
A Y
B Y
B Z
B Z
B X
B Z
A Y
B Z
A Y
B Z
C Z
A Z
A Z
B X
A X
B Z
B Z
A X
B X
C X
C X
A X
A Y
A X
B Z
C Y
B X
B Z
B X
A Y
A Y
A Y
B X
B Z
B Z
B Z
A Y
A Y
B Y
B Z
A Y
A Y
C Y
A Y
A X
A Y
A Y
A Y
B Z
B Z
A Y
B X
A Y
A Y
A Y
A Y
A X
A Y
B Z
A Y
A Y
B Z
A Y
A Y
A Y
B X
A Y
C Y
B X
A Y
A X
A Y
B Z
B Z
B Z
B Z
B Z
A Z
B Z
A Z
C Y
B X
B Y
A X
B X
B X
A Y
A Y
A Y
A Y
B Y
A Y
A Y
A X
A Y
B Y
B X
C Y
B X
C X
A Y
B Z
A Y
A Y
B Z
A Y
A Y
B X
A Y
C Y
A Y
A Y
A Y
C Z
A X
B Y
A Y
C Y
A Y
B Z
A Y
B Z
B X
A Y
A Y
C Y
A Y
B Y
B Z
A Y
B X
A Y
A Y
C Y
C X
A Y
B Z
A Y
B X
B Z
B X
B X
A Y
A Z
B X
A Z
A Y
C Y
B Y
B X
A Y
A Y
A Y
B X
B Z
B Y
B X
A Y
A Y
A Y
A Y
A X
A Y
B X
A Y
B Z
B Z
B X
A Y
A Y
C X
B Z
B Z
B Y
A Z
B Y
B Y
C Z
A X
B X
B X
A Y
A Y
B X
A Y
B Z
B X
B X
C X
B Z
A Y
A Y
B X
B Z
A Y
B Y
A Y
B X
B X
B X
B Y
A Y
B Z
A Y
B Y
B Z
B X
B X
A Y
A Y
A Y
C Y
B X
B Z
A Z
A Y
A Z
A Y
A Y
B Z
A Y
B Z
C Z
B X
A Y
B Z
A Y
A X
B Y
A X
C Y
B Z
B Z
A Y
A X
B Z
C Z
B Z
A Y
A Y
A Y
A Y
A Y
B Z
A Y
A Y
B Z
A Y
A Y
A Y
A Y
B X
B Z
A Y
A Y
C Y
B Z
A Y
C Y
C Z
B Z
A Y
A Y
C Z
B Z
B Y
B X
A Y
A Y
B Z
A Y
C X
B Z
B X
B Z
B X
B Z
B Z
B Z
A Y
A Y
A Y
C Y
A Y
A Y
B Z
B X
B X
A Y
A Y
A X
A Y
A Y
A X
B X
B Y
B Z
A Y
A X
C Z
A Y
C Y
B X
A X
B Z
A Y
B Z
B Z
B X
A Y
A Y
C Z
A Y
A X
A Y
A Y
C Z
A Y
B X
A Z
B Z
B X
A Y
A X
A Y
A Z
B X
B Z
A Y
B Y
A Y
A Y
A Y
A Y
A Y
A Y
B X
C Y
A X
B Z
B X
B X
A Y
A Y
B X
A Y
C Y
A Y
A Y
B X
A Y
C X
A Y
B Z
B X
A Y
A X
C X
A Y
A Y
B Y
A Y
B Z
C Z
B X
B Y
C X
A Y
B X
A Y
B X
B Z
B Y
A Y
A Y
A Y
A Y
A Y
A Y
A Y
B X
A Y
A Y
B Z
B Z
A Y
C Y
B X
A Y
A Y
A Y
B X
A Y
B Z
A Y
B X
B Y
B X
B Y
B X
B Z
A X
B Z
C Z
B Y
A Y
A X
A Z
B Z
B Z
B Z
A Y
A Y
A Y
A Y
A Y
B Z
A Y
A Y
B Y
A Y
A Y
C Z
B Y
C Y
A Y
B Z
A Y
B Z
A Y
B X
A Z
B Z
A Y
A Y
A Y
A Y
A Y
A Y
A Y
A Y
A Y
B Z
B X
A Y
B Z
A Y
A Z
A Y
B Y
A Y
B X
B X
B Z
A Y
A Y
A Y
B Z
B Y
A Y
B X
C Z
A X
B Z
B X
A Y
A Y
A Z
B X
A X
A Y
C Y
C Y
A Y
A Y
A Y
A Y
B Z
B X
B X
A Y
B X
A Y
B X
A Y
A X
B X
B Z
A Y
B X
B X
B Z
B Y
A Y
B Z
A Y
A Y
A Y
A Y
B Y
B Y
B X
B Y
B X
B X
A Y
C X
A X
B X
A Y
B Z
A Y
A Y
B Z
B X
A Y
B Z
B X
B Z
A Y
A Y
A Y
A Y
B Y
B Z
A X
B Z
B X
A Y
A Y
C Z
A Y
B X
B Z
A Y
A Y
C X
A Y
C Y
A Z
A Y
B Y
B X
A Y
B Z
A Y
A Y
A Y
A Y
A X
B Z
B X
B Z
A Y
A Y
B X
A Y
C Z
B X
B X
A Y
A Y
B X
B Y
A Y
A Y
A Y
B Z
A X
A Y
A Y
A Y
A Y
B X
B Z
C Y
B Z
B X
A Y
B Z
A Y
B Z
A Y
C X
A Y
A Y
C Y
A Y
A Y
A Y
A Y
A Y
B X
B Y
A X
A Y
B Z
C Y
A Y
A Y
B X
A X
A X
B X
A Y
A Y
A Y
A X
C Y
B X
A Y
A Y
A Y
A Y
A Y
A Y
B Z
A Y
B Z
C Y
A Y
A Y
A Y
A Y
B Z
B Z
A X
A Y
A X
A X
A Y
A Y
B Z
B X
A Y
A Y
B X
B Y
C Z
A X
A X
A Y
B X
A Y
B X
B Z
A Y
B X
A Y
A Y
B Z
B X
B X
B X
A Y
A Y
B Z
B Z
A Y
B Y
A Y
A Y
A Y
A Y
B X
A X
B Y
B X
A Y
C X
B Z
B X
A Y
B X
B X
B X
B Y
B Y
A Y
A Z
B Z
C Y
A Y
A Y
A Z
A X
A Y
C Y
A Y
B Z
A Y
C Y
C Y
B Z
A Y
B Z
B Z
A Y
B Z
A Y
C Y
B Z
B X
B X
A Y
A Y
C Y
A Y
A Y
A Y
A X
A Y
A Y
A Y
C Z
B X
B Y
B X
A Y
A Y
C Y
A Y
A Y
A Y
B Z
B Y
A X
B Z
A Y
A Y
C Y
A Y
A Y
C Y
B X
B X
A Y
C Z
A Y
A Y
A Y
C Y
B Y
B Z
B Y
C X
A Y
B Y
C Y
B Z
A Y
B X
B X
A Y
A Y
A Y
B Y
B Y
A Y
A Y
B X
A Y
B Y
A Y
A Y
B Z
B Z
A Z
B X
B Z
B X
A Y
A Y
B Z
B Z
C Y
A Y
B Z
B Y
A Y
B X
B Z
B Z
A X
B X
A Y
A Z
B Z
A Y
B X
A Y
A Y
A Y
B X
B X
B Z
A Y
A Y
A X
C X
A Y
A X
B Z
B Z
A Y
C Y
B Z
B Z
B Y
B Z
A X
A Y
A Y
B Z
B X
A Y
C Z
A X
A Y
B Z
B X
C Y
A Y
A Y
B Y
B X
A Z
B X
A Y
A Y
B Z
C Z
B Z
B Z
A Y
A Y
A Y
B X
A Y
A X
C X
A Y
A Y
B Z
A Y
B Y
B X
A Z
A Y
A Y
A Y
C Y
B X
B Y
A Y
B Y
C Z
B X
B Z
B Z
B X
A Y
B Z
B X
A Y
A X
B Y
A Y
A Z
B X
B Z
A Y
C Z
B X
B Z
A Y
A X
A Y
B Z
B Z
A X
C Y
B X
C Z
B Y
A X
B X
C Y
A Y
B Y
B Z
A Y
A Y
A Y
A Y
B Y
B Z
B X
B X
A Y
A Z
B X
A Y
A Y
A Y
A X
B Z
C Z
C Y
B X
A Y
A Y
A Y
C X
B Z
B Z
A Y
A X
B X
A Y
B X
A X
B X
B Z
B X
B X
A Y
A Y
B X
A Y
A Y
A Y
B Z
B Y
B Z
A Y
A Y
A Y
B Z
A Y
A Y
A Y
C Y
B Y
B Z
A Y
B X
B Z
B Y
B X
A Y
A Y
A Y
A Y
C Z
A Y
A X
A Y
A Y
A Y
A Y
B Z
B Z
B Z
C Y
A Y
A Y
A Y
A Z
A Y
C Y
A Y
A Y
B Z
A Y
A Y
A Y
B X
A Y
B Y
A Y
A Y
B Z
B X
A Y
A Y
B Y
B X
A Y
B X
A Y
A Y
A Y
A Z
A Y
B X
B Y
B X
C Y
B Z
A X
A Y
A Y
A Y
B Z
B X
B X
B Z
B Y
A Y
A Z
A Y
C Z
B X
A Y
B Z
B Z
B Y
B X
A Y
C X
A Y
A Y
A Y
A Y
B Z
B Z
A Y
A Y
A Y
B Z
A Y
A Y
A Y
A Y
A Y
A Y
A Y
B X
A Y
C Y
B Z
B Z
A Y
A Y
A Y
B Y
A X
B Z
A X
B Z
B Y
A Y
B Z
B X
B X
A Y
A Y
A Y
B Z
A Y
A Y
B X
B X
A Y
B X
A Y
B X
A Y
B Z
A Y
B X
A Z
B Z
A Y
C Y
A Y
A Y
C Y
A Y
A Y
A X
A Y
C Y
A Y
A Y
B X
A Y
A Y
B X
C Y
A Y
B X
C Z
B Z
B Y
A Y
B Z
B Y
A X
A X
A Y
A Y
A Y
B X
B Z
C Y
B X
B Z
A Y
A Y
A Y
A Y
B X
B Y
C Y
A Y
A Y
A Y
B Z
B Y
A Y
B X
B Z
A Y
A Y
A Y
A Y
B Y
A X
A X
B Z
B Y
C Y
B Z
B Z
A Y
A Y
B Z
A Y
B Z
C X
A Y
A Y
B Y
A Y
B Z
A Y
B Z
B Z
A Y
A Y
C Z
C Y
A Y
A Y
C Y
A Y
C Y
A Y
B Z
A Y
B X
A X
B Z
A Y
A Y
A Y
B Z
A Z
C Y
A Y
A Y
A Y
B X
B X
A Y
A Y
A X
A Y
B Y
B X
B X
A Y
A Y
C Y
A Z
A Y
B X
B X
B Z
A Y
A Y
B Y
C Y
B X
A Y
A Y
A Y
A Y
A X
B X
A Y
A Y
B Z
A X
C Y
B X
A Y
B Z
A Y
A Y
C Y
A Y
A X
A Y
A Y
B Z
A Y
C Z
A Y
B X
B X
B Y
B Z
A Y
A Y
A Y
B Z
A Y
B Z
A Y
A X
A Z
A Y
C Z
B X
A Y
B Z
B Y
A Y
B X
B Z
B Z
B Z
A Y
A X
B Y
B X
A Y
A Y
A Y
B X
A Y
A Y
B Z
A Y
C Y
B X
A Y
A Y
C Z
B Z
A Y
B Z
B Z
B Z
A Y
B Z
B Y
A Y
A Y
C Y
A Y
B Y
A Y
B X
A Y
C Z
A Y
B X
A X
A Y
A Y
B Z
A Y
B X
B Z
B X
A Y
A Y
A Y
A Y
B Z
A Y
B Z
A Y
A Y
C Y
A Y
C Y
B X
B X
A Y
A X
B Z
B X
A Y
A Y
A Y
A Y
B Y
C Y
A X
B X
A Y
C Y
B Y
A Y
B Y
B Z
A Y
B Z
B X
A Y
B X
A Y
C Y
A Y
B X
B Z
A Y
A Y
A Y
A X
A Y
A Z
C Z
A Y
B Z
A Y
B X
B X
A Y
C Y
C Y
A Y
A Y
B Y
A Y
C Z
B Z
C Y
B X
A Y
B Z
A Y
B X
C Y
B X
A Y
A Y
B X
B Z
A Y
B Z
C Y
B X
A Y
B Z
A Y
B Z
B Z
B Z
A Y
A Y
A Y
";

    public async Task Execute()
    {
        var score = Input.Split(Environment.NewLine)
                         .Where(line => !string.IsNullOrEmpty(line))
                         .Select(line =>
                         {
                             var moves = line.Split(" ");

                             return new
                             {
                                 opponentMove = GetMove(moves[0]),
                                 myMove = GetMove(moves[1])
                             };
                         })
                         .Select(t => GetResult(t.opponentMove, t.myMove).GetDefaultValue<int>() + t.myMove.GetDefaultValue<int>())
                         .Sum();

        System.Console.WriteLine(score);
    }

    private MoveType GetMove(string move)
    {
        return move switch
        {
            "A" or "X" => MoveType.Rock,
            "B" or "Y" => MoveType.Paper,
            "C" or "Z" => MoveType.Scissors,
            _ => throw new Exception("what")
        };
    }

    private Result GetResult(MoveType opponentMove, MoveType myMove)
    {
        if (opponentMove == myMove)
        {
            return Result.Draw;
        }

        if ((opponentMove == MoveType.Rock && myMove == MoveType.Scissors) ||
            (opponentMove == MoveType.Scissors && myMove == MoveType.Paper) ||
            (opponentMove == MoveType.Paper && myMove == MoveType.Rock))
        {
            return Result.Lose;
        }

        return Result.Win;
    }

    private enum MoveType
    {
        [DefaultValue(1)]
        Rock,

        [DefaultValue(2)]
        Paper,

        [DefaultValue(3)]
        Scissors
    }

    private enum Result
    {
        [DefaultValue(0)]
        Lose,

        [DefaultValue(3)]
        Draw,

        [DefaultValue(6)]
        Win
    }
}