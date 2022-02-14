using CardLib;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KarliCards.Gui
{
    /// <summary>
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        private Card card;
        public CardControl(Card card)
        {
            InitializeComponent();
            Card = card;
        }

        public Suit Suit
        {
            get { return (Suit)GetValue(SuitProperty); }
            set { SetValue(SuitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Suit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuitProperty =
            DependencyProperty.Register("Suit", typeof(Suit), typeof(CardControl), new PropertyMetadata(Suit.Club, new PropertyChangedCallback(OnSuitChanged)));

        public Rank Rank
        {
            get { return (Rank)GetValue(RankProperty); }
            set { SetValue(RankProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rank.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RankProperty =
            DependencyProperty.Register("Rank", typeof(Rank), typeof(CardControl), new PropertyMetadata(Rank.Ace));

        public bool IsFaceUp
        {
            get { return (bool)GetValue(IsFaceUpProperty); }
            set { SetValue(IsFaceUpProperty, value); }
        }

        public Card Card 
        { 
            get => card; 
            private set { card = value; Suit = card.suit; Rank = card.rank; }
        }

        // Using a DependencyProperty as the backing store for IsFaceUp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFaceUpProperty =
            DependencyProperty.Register("IsFaceUp", typeof(bool), typeof(CardControl), new PropertyMetadata(true, new PropertyChangedCallback(OnIsFaceUpChanged)));

        private static void OnSuitChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var control = source as CardControl;
            control.SetTextColor();
        }

        private static void OnIsFaceUpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CardControl;
            control.RankLabel.Visibility = control.SuitLabel.Visibility
                = control.RankLabelInverted.Visibility
                = control.TopRightImage.Visibility
                = control.BottomLeftImage.Visibility
                = control.IsFaceUp ? Visibility.Visible : Visibility.Hidden;
        }

        private void SetTextColor()
        {
            var color = (Suit == Suit.Club || Suit == Suit.Spade) ? new SolidColorBrush(Color.FromRgb(0, 0, 0)) : new SolidColorBrush(Color.FromRgb(255, 0, 0));
            RankLabel.Foreground = SuitLabel.Foreground = RankLabelInverted.Foreground = color;
        }
    }
}
