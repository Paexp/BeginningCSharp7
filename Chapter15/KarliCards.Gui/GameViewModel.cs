using CardLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace KarliCards.Gui
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private Player currentPlayer;

        private GameOptions gameOptions;

        public static RoutedCommand StartGameCommand = new RoutedCommand("Start New Game", typeof(GameViewModel),
            new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.N, ModifierKeys.Control) }));

        public static RoutedCommand ShowAboutCommand = new RoutedCommand("Show About Dialog", typeof(GameViewModel));

        public Player CurrentPlayer
        {
            get => currentPlayer;
            set
            {
                currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public List<Player> Players { get; set; }

        public Card CurrentAvailableCard { get; set; }
        public Deck GameDeck { get; set; }
        public bool GameStarted { get; set; }

        public GameViewModel()
        {
            Players = new List<Player>();
            gameOptions = GameOptions.Create();
        }

        public void StartNewGame()
        {
            if (gameOptions.SelectedPlayers.Count < 1 || (gameOptions.SelectedPlayers.Count == 1 && !gameOptions.PlayAgainstComputer))
                return;
            CreateGameDeck();
            CreatePlayers();
            InitializeGame();
            GameStarted = true;
        }

        private void InitializeGame()
        {
            AssignCurrentPlayer(0);
            CurrentAvailableCard = GameDeck.Draw();
        }

        private void AssignCurrentPlayer(int index)
        {
            CurrentPlayer = Players[index];
            if (!Players.Any(x => x.State == PlayerState.Winner))
                Players.ForEach(x => x.State = (x == Players[index] ? PlayerState.Active : PlayerState.Inactive));
        }

        private void CreatePlayers()
        {
            Players.Clear();
            for (var i = 0; i < gameOptions.NumberOfPlayers; i++)
            {
                if (i < gameOptions.SelectedPlayers.Count)
                    InitializePlayer(new Player
                    {
                        Index = i,
                        PlayerName = gameOptions.SelectedPlayers[i]
                    });
                else
                    InitializePlayer(new ComputerPlayer
                    {
                        Index = i,
                        Skill = (CardLib.ComputerSkillLevel)gameOptions.ComputerSkillLevel
                    });
            }
        }

        private void InitializePlayer(Player player)
        {
            player.DrawNewHand(GameDeck);
            player.OnCardDiscarded += player_OnCardDiscarded;
            player.OnPlayerHasWon += player_OnPlayerHasWon;
            Players.Add(player);
        }

        private void player_OnPlayerHasWon(object? sender, PlayerEventArgs e)
        {
            Players.ForEach(x => x.State = (x == e.Player ? PlayerState.Winner : PlayerState.Loser));
        }

        private void player_OnCardDiscarded(object? sender, CardEventArgs e)
        {
            CurrentAvailableCard = e.Card;
            var nextIndex = CurrentPlayer.Index + 1 >= gameOptions.NumberOfPlayers ? 0 : CurrentPlayer.Index + 1;
            if (GameDeck.CardsInDeck == 0)
            {
                var cardsInPlay = new List<Card>();
                foreach (var player in Players)
                    cardsInPlay.AddRange(player.GetCards());
                cardsInPlay.Add(CurrentAvailableCard);
                GameDeck.ReshuffleDiscarded(cardsInPlay);
            }
            AssignCurrentPlayer(nextIndex);
        }

        private void CreateGameDeck()
        {
            GameDeck = new Deck();
            GameDeck.Shuffle();
        }
    }
}
