using NUnit.Framework;

namespace Aoc2025.Day01;

internal class Day01
{
    private readonly List<KeyValuePair<string, int>> steps = [];
    private int currentState = 50;
    public int CountZeroStops { get; private set; }
    public int CountZeroCrossings { get; private set; }

    public Day01(string input)
    {
        var lines = input.Split(Environment.NewLine);
        steps = lines
            .Select(line => new KeyValuePair<string, int> (
                line.Substring(0,1), 
                int.Parse(line.Substring(1))
            ))
            .ToList();
    }

    public int Run()
    {
        foreach (var step in steps)
        {
            RunStep(step.Key == "L", step.Value);
        }
        return currentState;
    }

    public void RunStep(bool goLeft, int steps)
    {
        var initialState = currentState;

        while (steps > 100)
        {
            // count the full spins
            var fullSpins = steps / 100;
            CountZeroCrossings += fullSpins;
            steps = steps % 100;
        }

        var delta = goLeft ? -steps : steps;

        currentState += delta;

        // detect exact 0
        if (currentState == 0 || currentState == 100)
        {
            CountZeroStops++;
            CountZeroCrossings++;
            currentState = 0;
        }
        else
        {
            if (currentState < 0)
            {
                currentState += 100;
                if (initialState != 0)
                {
                    CountZeroCrossings++;
                }
            }
            else
            {
                if (currentState >= 100)
                {
                    currentState -= 100;
                    CountZeroCrossings++;
                }
            }
        }

        Assert.That(currentState >= 0 && currentState < 100);

        //else {
        //    // correct for overflow
        //    while (currentState < 0)
        //    {
        //        currentState += 100;
        //        if (initialState != 0)
        //        {
        //            CountZeroCrossings++;
        //        }
        //    }

        //    while (currentState >= 100)
        //    {
        //        currentState -= 100;
        //        CountZeroCrossings++;
        //    }
        //}

        //    {
        //var newState = currentState % 100;
        //if (currentState != newState + 100)
        //{
        //    // overflow detected
        //    if (steps > 100)
        //    {
        //        //
        //        var extraSteps = steps / 100;
        //        CountZeroCrossings += extraSteps;
        //    }
        //    else
        //    {
        //        CountZeroCrossings++;
        //    }

        //    currentState = newState;
        //}
    }
}
