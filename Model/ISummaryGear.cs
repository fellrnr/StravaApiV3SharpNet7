using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="SummaryGear"/> and <see cref="DetailedGear"/></summary>
    public interface ISummaryGear
    {

        /// <summary>The gear's unique identifier.</summary>
        string Id { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 2 -> "summary", 3 -> "detail"</summary>
        ResourceState? ResourceState { get; }

        /// <summary>Whether this gear's is the owner's default one.</summary>
        bool? Primary { get; }

        /// <summary>The gear's name.</summary>
        string Name { get; }

        /// <summary>The distance logged with this gear.</summary>
        float? Distance { get; }

        /// <summary>The given nickname to the gear</summary>
        string Nickname { get; }

        /// <summary>Whether the gear is marked as retired</summary>
        bool? Retired { get; }

    }
}

