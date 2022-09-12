using BrilliantBingo.Code.Infrastructure.Events.Handlers;

namespace BrilliantBingo.Code.Infrastructure.Generators.Interfaces
{
    public interface IBingoBallsSource
    {
        #region Events

        event BingoBallGeneratedEventHandler BingoBallGenerated;

        #endregion

        #region Methods

        void Begin(float frequency);

        void Stop();

        #endregion
    }
}