using System;

namespace CardLib
{
    [Serializable]
    public enum PlayerState
    {
        Inactive, Active, MustDiscard, Winner, Loser
    }
}