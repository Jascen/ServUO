namespace Server.Spells
{
    public partial class SpellHelper
    {
        private static readonly bool[,] m_Rules = new bool[,]
        {
            /*T2A(Fel),	Khaldun,	Ilshenar,	Wind(Tram),	Wind(Fel),	Dungeons(Fel),	Solen(Tram),	Solen(Fel),	CrystalCave(Malas),	Gauntlet(Malas),	Gauntlet(Ferry),	SafeZone,	Stronghold,	ChampionSpawn,	Dungeons(Tokuno[Malas]),	LampRoom(Doom),	GuardianRoom(Doom),	Heartwood,	MLDungeons, Eodon*/
/* Recall From */	{ true,    false,      true,       true,       false,      true,          true,           true,      false,              true,              true,              true,       true,       true,          true,                       false,          true,              true,      true,      true} ,
/* Recall To */		{ false,    false,      false,      false,      false,      false,          false,          false,      false,              false,              false,              false,      false,      false,          false,                      false,          false,              false,      false,      false },
/* Gate From */		{ false,    false,      false,      false,      false,      false,          false,          false,      false,              false,              false,              false,      false,      false,          false,                      false,          false,              false,      false,      false },
/* Gate To */		{ false,    false,      false,      false,      false,      false,          false,          false,      false,              false,              false,              false,      false,      false,          false,                      false,          false,              false,      false,      false },
/* Mark In */		{ false,    false,      false,      false,      false,      false,          false,          false,      false,              false,              false,              false,      false,      false,          false,                      false,          false,              false,      false,      false },
/* Tele From */		{ true,     true,       true,       true,       true,       true,           true,           true,       false,              true,               true,               true,       false,      true,           true,                       true,           true,               true,      true,       true },
/* Tele To */		{ true,     true,       true,       true,       true,       true,           true,           true,       false,              false,               false,              false,      false,      true,           true,                       true,           true,               true,      true,      true },
        };
    }
}