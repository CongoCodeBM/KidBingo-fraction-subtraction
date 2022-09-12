using System;
using BrilliantBingo.Code.Infrastructure.Models;

namespace BrilliantBingo.Code.Infrastructure.Events.Args
{
    public class BingoBallGeneratedEventArgs : EventArgs
    {
        public BingoBallGeneratedEventArgs(BingoBall ball)
        {
            if (ball == null)
            {
                throw new ArgumentNullException("ball");
            }
            Ball = ball;
        }

        public BingoBall Ball { get; private set; }
    }
}