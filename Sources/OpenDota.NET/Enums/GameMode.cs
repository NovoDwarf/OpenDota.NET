using OpenDota.NET.Converters;

namespace OpenDota.NET.Enums;

/// <summary>Values from the OpenDota dotaconstants repository.</summary>
[JsonConverter(typeof(NumericEnumConverter<GameMode>))]
public enum GameMode : long
{
    /// <summary>game_mode_unknown.</summary>
    Unknown = 0,
    /// <summary>game_mode_all_pick.</summary>
    AllPick = 1,
    /// <summary>game_mode_captains_mode.</summary>
    CaptainsMode = 2,
    /// <summary>game_mode_random_draft.</summary>
    RandomDraft = 3,
    /// <summary>game_mode_single_draft.</summary>
    SingleDraft = 4,
    /// <summary>game_mode_all_random.</summary>
    AllRandom = 5,
    /// <summary>game_mode_intro.</summary>
    Intro = 6,
    /// <summary>game_mode_diretide.</summary>
    Diretide = 7,
    /// <summary>game_mode_reverse_captains_mode.</summary>
    ReverseCaptainsMode = 8,
    /// <summary>game_mode_greeviling.</summary>
    Greeviling = 9,
    /// <summary>game_mode_tutorial.</summary>
    Tutorial = 10,
    /// <summary>game_mode_mid_only.</summary>
    MidOnly = 11,
    /// <summary>game_mode_least_played.</summary>
    LeastPlayed = 12,
    /// <summary>game_mode_limited_heroes.</summary>
    LimitedHeroes = 13,
    /// <summary>game_mode_compendium_matchmaking.</summary>
    CompendiumMatchmaking = 14,
    /// <summary>game_mode_custom.</summary>
    Custom = 15,
    /// <summary>game_mode_captains_draft.</summary>
    CaptainsDraft = 16,
    /// <summary>game_mode_balanced_draft.</summary>
    BalancedDraft = 17,
    /// <summary>game_mode_ability_draft.</summary>
    AbilityDraft = 18,
    /// <summary>game_mode_event.</summary>
    Event = 19,
    /// <summary>game_mode_all_random_death_match.</summary>
    AllRandomDeathMatch = 20,
    /// <summary>game_mode_1v1_mid.</summary>
    Mode1v1Mid = 21,
    /// <summary>game_mode_all_draft.</summary>
    AllDraft = 22,
    /// <summary>game_mode_turbo.</summary>
    Turbo = 23,
    /// <summary>game_mode_mutation.</summary>
    Mutation = 24,
    /// <summary>game_mode_coaches_challenge.</summary>
    CoachesChallenge = 25,
}
