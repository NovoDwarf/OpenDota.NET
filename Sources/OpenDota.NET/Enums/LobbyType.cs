namespace OpenDotaDotNet.Enums;

/// <summary>Values from the OpenDota dotaconstants repository.</summary>
[JsonConverter(typeof(NumericEnumConverter<LobbyType>))]
public enum LobbyType : long
{
    /// <summary>lobby_type_normal.</summary>
    Normal = 0,
    /// <summary>lobby_type_practice.</summary>
    Practice = 1,
    /// <summary>lobby_type_tournament.</summary>
    Tournament = 2,
    /// <summary>lobby_type_tutorial.</summary>
    Tutorial = 3,
    /// <summary>lobby_type_coop_bots.</summary>
    CoopBots = 4,
    /// <summary>lobby_type_ranked_team_mm.</summary>
    RankedTeamMm = 5,
    /// <summary>lobby_type_ranked_solo_mm.</summary>
    RankedSoloMm = 6,
    /// <summary>lobby_type_ranked.</summary>
    Ranked = 7,
    /// <summary>lobby_type_1v1_mid.</summary>
    Mode1v1Mid = 8,
    /// <summary>lobby_type_battle_cup.</summary>
    BattleCup = 9,
    /// <summary>lobby_type_local_bots.</summary>
    LocalBots = 10,
    /// <summary>lobby_type_spectator.</summary>
    Spectator = 11,
    /// <summary>lobby_type_event.</summary>
    Event = 12,
    /// <summary>lobby_type_gauntlet.</summary>
    Gauntlet = 13,
    /// <summary>lobby_type_new_player.</summary>
    NewPlayer = 14,
    /// <summary>lobby_type_featured.</summary>
    Featured = 15,
}
