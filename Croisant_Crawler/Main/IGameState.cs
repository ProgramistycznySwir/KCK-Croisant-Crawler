

namespace Croisant_Crawler;

// TODO: Conceptualize Game, Fight_Game and HeroTab to be State pattern.
public interface IGameState
{
	public IGameState GetPreviousState();
	public IGameState Init();
}