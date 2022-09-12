using BrilliantBingo.Code.Infrastructure.Events.Args;

namespace BrilliantBingo.Code.Infrastructure.Events.Handlers
{
    public delegate void AllCardsFinishToPlayEventHandler(object sender, AllCardsFinishToPlayEventArgs e);
}