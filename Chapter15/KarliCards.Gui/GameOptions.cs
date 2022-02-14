using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;

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

        public static RoutedCommand OptionsCommand = new RoutedCommand("Show Options", typeof(GameOptions), 
            new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.O, ModifierKeys.Control) }));

        public void Save()
        {
            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, this);
            }
        }

        public static GameOptions Create()
        {
            if (File.Exists("GameOptions.xml"))
            {
                using (var stream = File.OpenRead("GameOptions.xml"))
                {
                    var serializer = new XmlSerializer(typeof(GameOptions));
                    return serializer.Deserialize(stream) as GameOptions;
                }
            }
            else
            {
                return new GameOptions();
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
