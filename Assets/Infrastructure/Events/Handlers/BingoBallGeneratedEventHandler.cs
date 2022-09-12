using BrilliantBingo.Code.Infrastructure.Events.Args;

namespace BrilliantBingo.Code.Infrastructure.Events.Handlers
{
    public delegate void BingoBallGeneratedEventHandler(object sender, BingoBallGeneratedEventArgs e);
}