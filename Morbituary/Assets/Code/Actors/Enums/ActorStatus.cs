using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Actors.Enums
{
    /// <summary>
    /// The different Statuses for an Actor, which we might also want to use for Animation.
    /// However, maybe unity already has something for this integrated
    /// </summary>
    public enum ActorStatus
    {
        Idle, Walking, Attacking, Dead
    }
}
