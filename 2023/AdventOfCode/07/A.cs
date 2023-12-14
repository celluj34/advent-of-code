using System.ComponentModel.DataAnnotations;
using AdventOfCode.Extensions;

namespace AdventOfCode._07;

public class A
{
    public void Execute()
    {
        var total = Input.Day7.Split(Environment.NewLine)
                         .Select(x =>
                         {
                             var parts = x.Split(" ");

                             var hand = parts[0].Select(y => Convert.ToString(y).ToEnumFromDisplayName<Cards>()).ToList();
                             var rank = GetRank(hand);
                             var bid = int.Parse(parts[1]);

                             return new
                             {
                                 hand,
                                 rank,
                                 bid
                             };
                         })
                         .OrderByDescending(x => x.rank)
                         .ThenByDescending(x => x.hand[0])
                         .ThenByDescending(x => x.hand[1])
                         .ThenByDescending(x => x.hand[2])
                         .ThenByDescending(x => x.hand[3])
                         .ThenByDescending(x => x.hand[4])
                         .Select((x, i) => x.bid * (i + 1))
                         .Sum();

        Console.WriteLine(total);
    }

    private HandRank GetRank(IReadOnlyCollection<Cards> hand)
    {
        if (hand.Distinct().Count() == 1)
        {
            return HandRank.FiveOfAKind;
        }

        if (hand.GroupBy(x => x).Any(x => x.Count() == 4))
        {
            return HandRank.FourOfAKind;
        }

        if (hand.GroupBy(x => x).Any(x => x.Count() == 3) && hand.GroupBy(x => x).Any(x => x.Count() == 2))
        {
            return HandRank.FullHouse;
        }

        if (hand.GroupBy(x => x).Any(x => x.Count() == 3))
        {
            return HandRank.ThreeOfAKind;
        }

        if (hand.GroupBy(x => x).Count(x => x.Count() == 2) == 2)
        {
            return HandRank.TwoPair;
        }

        if (hand.GroupBy(x => x).Any(x => x.Count() == 2))
        {
            return HandRank.Pair;
        }

        return HandRank.HighCard;
    }

    private enum HandRank
    {
        FiveOfAKind,
        FourOfAKind,
        FullHouse,
        ThreeOfAKind,
        TwoPair,
        Pair,
        HighCard
    }

    private enum Cards
    {
        [Display(Name = "A")]
        Ace,

        [Display(Name = "K")]
        King,

        [Display(Name = "Q")]
        Queen,

        [Display(Name = "J")]
        Jack,

        [Display(Name = "T")]
        Ten,

        [Display(Name = "9")]
        Nine,

        [Display(Name = "8")]
        Eight,

        [Display(Name = "7")]
        Seven,

        [Display(Name = "6")]
        Six,

        [Display(Name = "5")]
        Five,

        [Display(Name = "4")]
        Four,

        [Display(Name = "3")]
        Three,

        [Display(Name = "2")]
        Two
    }
}