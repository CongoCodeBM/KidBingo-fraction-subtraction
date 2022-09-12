using BrilliantBingo.Code.Infrastructure.Events.Args;

namespace BrilliantBingo.Code.Infrastructure.Events.Handlers
{
    public delegate void CardNumberMarkedEventHandler(object sender, CardNumberMarkedEventArgs e);
}