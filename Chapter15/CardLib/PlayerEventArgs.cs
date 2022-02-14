using System;

namespace CardLib
{
    public class PlayerEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public PlayerState State { get; set; }
    }

}
