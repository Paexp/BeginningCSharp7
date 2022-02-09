using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace KarliCards.Gui
{
    [Serializable]
    public class GameOptions : INotifyPropertyChanged
    {
        private bool playAgainstComputer = true;
        private int numberOfPlayers = 2;
        private ComputerSkillLevel computerSkillLevel = ComputerSkillLevel.Dumb;
        private ObservableCollection<string> playerNames = new ObservableCollection<string>();

        public bool PlayAgainstComputer
        {
            get => playAgainstComputer;
            set
            {
                playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
        }

        public int NumberOfPlayers
        {
            get => numberOfPlayers;
            set
            {
                numberOfPlayers = value;
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }

        public ObservableCollection<string> PlayerNames
        {
            get => playerNames;
            set
            {
                playerNames = value;
                OnPropertyChanged(nameof(PlayerNames));
            }
        }

        public void AddPlayer(string playerName)
        {
            if(playerNames.Contains(playerName))
                return;
            playerNames.Add(playerName);
            OnPropertyChanged(nameof(PlayerNames));
        }

        public List<string> SelectedPlayers { get; set; } = new List<string>();

        public int MinutesBeforeLoss { get; set; }

        public ComputerSkillLevel ComputerSkillLevel 
        { 
            get => computerSkillLevel;
            set
            {
                computerSkillLevel = value;
                OnPropertyChanged(nameof(ComputerSkillLevel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [Serializable]
    public enum ComputerSkillLevel
    {
        Dumb,
        Good,
        Cheats
    }
}
