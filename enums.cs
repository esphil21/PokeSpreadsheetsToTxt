using System.Collections.Generic;

public enum PKMNtxtLine
{
    Null = -1,
    DexNum = 0,
    Type1 = 1,
    Type2 = 2,              //?
    BaseStats = 3,
    GenderRate = 4,
    GrowthRate = 5,
    BaseEXP = 6,
    EffortPoints = 7,
    Rareness = 8,
    Happiness = 9,
    Abilities = 10,
    HiddenAbility = 11,     //?
    Moves = 12,
    TutorMoves = 13,
    EggMoves = 14,          //?
    Compatibility = 15,
    StepsToHatch = 16,
    Height = 17,
    Weight = 18,
    Color = 19,
    Shape = 20,
    Habitat = 21,           //?
    Kind = 22,
    Pokedex = 23,
    Generation = 24,
    BattlerPlayerX = 25,    //?
    BattlerPlayerY = 26,    //?
    BattlerEnemyX = 27,     //?
    BattlerEnemyY = 28,     //?
    BattlerShadowX = 29,    //?
    BattlerShadowSize = 30, //?
    Evolutions = 31         //?
}

public enum SheetName
{
    VersionUpdates = 0,
    DevNotes = 1,
    BugReport = 2,
    Lore = 3,
    Walkthrough = 4,
    RegionMap = 5,
    PKMNSpawns = 6,
    GuardianLocations = 7,
    ItemLocations = 8,
    NPCBattles = 9,
    TypeChart = 10,
    SimpleTypeChart = 11,
    NationalDex = 12,
    NationalDexFilters = 13,
    PKMNSearch = 14,
    EvolutionMethods = 15,
    MoveSets = 16,
    TM_Moves = 17,
    TR_Moves = 18,
    TutorMoves = 19,
    MoveGlossary = 20,
    AdditionalEffects = 21,
    AbilityGlossary = 22,
    ItemGlossary = 23,
    TerrainGlossary = 24,
    WeatherGlossary = 25,
    MusicCredit = 26,
    Test = 27,
}

public enum NatDexCol
{
    Num = 1,
    Pokemon_Name = 2,
    Altered = 3,
    Type1 = 4,
    Type2 = 5,
    Ability1 = 6,
    Ability2 = 7,
    HiddenAbility = 8,
    HP = 9,
    ATK = 10,
    DEF = 11,
    SP_ATK = 12,
    SP_DEF = 13,
    SPE = 14,
    BST = 15,
    WildHeldItem = 16,
    EggGroup1 = 17,
    EggGroup2 = 18,
    Gen = 19,
    Starter = 20,
    Guardian = 21,
    PostGame = 22,
    DexEntry = 23,
    Category = 24,
    Height = 25,
    Weight = 26,
    Color = 27,
    Shape = 28,
    GenderRate = 29,
    GrowthRate = 30,
    BaseEXP = 31,
    EffortPoints = 32,
    EffortPoints_TXT = 33,
    Rareness = 34,
    Happiness = 35,
    StepsToHatch = 36
}

public enum MoveSetsCol
{
    Num = 1,
    Pokemon_Name = 2,
    AceMoves = 3,
    LearnSet = 4,
    EggMoves = 5,
    EggGroup1 = 6,
    EggGroup2 = 7
}

public enum EvolutionMethodsCol
{
    Num = 1,
    Pokemon_Name = 2,
    Split = 3,
    Type1 = 4,
    Type2 = 5,
    EvolutionMethod = 6,
    EvolvesInto = 7,
    Type1_Evo = 8,
    Type2_Evo = 9,
    AdditionalNotes = 10
}

public enum PokeType
{
    NULL = 0,
    NORMAL = 1,
    FIGHTING = 2,
    FLYING = 3,
    POISON = 4,
    GROUND = 5,
    ROCK = 6,
    BUG = 7,
    GHOST = 8,
    STEEL = 9,
    FIRE = 10,
    WATER = 11,
    GRASS = 12,
    ELECTRIC = 13,
    PSYCHIC = 14,
    ICE = 15,
    DRAGON = 16,
    DARK = 17,
    FAIRY = 18,
    STAR = 19,
    SOUND = 20
}

public enum PokeAbility
{
    NULL = 0,
    ADAPTABILITY = 1,
    AERILATE = 2,
    AFTERMATH = 3,
    AIRLOCK = 4,
    ALLOY = 5,
    AMPLIFIER = 6,
    ANALYTIC = 7,
    ANGERPOINT = 8,
    ANTICIPATION = 9,
    ARENATRAP = 10,
    AROMAVEIL = 11,
    ASTRONOMER = 12,
    AURABOOST = 13,
    AURABREAK = 14,
    BADDREAMS = 15,
    BALLFETCH = 16,
    BATTERY = 17,
    BATTLEARMOR = 18,
    BATTLEBOND = 19,
    BEASTBOOST = 20,
    BERSERK = 21,
    BIGPECKS = 22,
    BLAZE = 23,
    BULLETPROOF = 24,
    BURNBRIGHT = 25,
    CACOPHONY = 26,
    CHARGEDSHOT = 27,
    CHEEKPOUCH = 28,
    CHILLINGAURA = 29,
    CHLOROPHYLL = 30,
    CLEARBODY = 31,
    CLOUDNINE = 32,
    COLORCHANGE = 33,
    COMATOSE = 34,
    COMPETITIVE = 35,
    COMPOUNDEYES = 36,
    CONTRARY = 37,
    CORROSION = 38,
    COSMICSIPHON = 39,
    COSMICSURGE = 40,
    COTTONDOWN = 41,
    CURIOUSMEDICINE = 42,
    CURSEDBODY = 43,
    CUTECHARM = 44,
    DAMP = 45,
    DANCER = 46,
    DARKAURA = 47,
    DAUNTLESSSHIELD = 48,
    DAZZLING = 49,
    DEFEATIST = 50,
    DEFIANT = 51,
    DELTASTREAM = 52,
    DESOLATELAND = 53,
    DISGUISE = 54,
    DOWNLOAD = 55,
    DRACONICSPIRIT = 56,
    DRIZZLE = 57,
    DROPANCHOR = 58,
    DROUGHT = 59,
    DRYSKIN = 60,
    EARLYBIRD = 61,
    EFFECTSPORE = 62,
    ELECTRICSURGE = 63,
    ELECTROVORE = 64,
    EMERGENCYEXIT = 65,
    ENERGYSHIELD = 66,
    EVENTHORIZON = 67,
    FAIRYAURA = 68,
    FEATHERDOWN = 69,
    FIGHTINGFIT = 70,
    FILTER = 71,
    FLAMEBODY = 72,
    FLAREBOOST = 73,
    FLASHFIRE = 74,
    FLOWERGIFT = 75,
    FLOWERVEIL = 76,
    FLUFFY = 77,
    FLYINGACE = 78,
    FORECAST = 79,
    FOREWARN = 80,
    FRIENDGUARD = 81,
    FRISK = 82,
    FULLMETALBODY = 83,
    FURCOAT = 84,
    GALEWINGS = 85,
    GALVANIZE = 86,
    GLUTTONY = 87,
    GOOEY = 88,
    GORILLATACTICS = 89,
    GRASSPELT = 90,
    GRASSYSURGE = 91,
    GRAVITON = 92,
    GULPMISSILE = 93,
    GUTS = 94,
    HARVEST = 95,
    HEALER = 96,
    HEATPROOF = 97,
    HEAVYMETAL = 98,
    HERBIVORE = 99,
    HONEYGATHER = 100,
    HUGEPOWER = 101,
    HUNGERSWITCH = 102,
    HUSTLE = 103,
    HYDRATION = 104,
    HYPERCUTTER = 105,
    ICEBODY = 106,
    ICEFACE = 107,
    ICESCALES = 108,
    ILLUMINATE = 109,
    ILLUSION = 110,
    IMMUNITY = 111,
    IMPOSTER = 112,
    INFILTRATOR = 113,
    INNARDSOUT = 114,
    INNERFOCUS = 115,
    INNERRHYTHM = 116,
    INSOMNIA = 117,
    INTANGIBLE = 118,
    INTERSTELLAR = 119,
    INTIMIDATE = 120,
    INTREPIDSWORD = 121,
    IRONBARBS = 122,
    IRONFIST = 123,
    JETSTREAM = 124,
    JUSTIFIED = 125,
    KEENEYE = 126,
    KLUTZ = 127,
    LEAFGUARD = 128,
    LEVITATE = 129,
    LIBERO = 130,
    LIGHTMETAL = 131,
    LIGHTNINGROD = 132,
    LIMBER = 133,
    LIQUIDOOZE = 134,
    LIQUIDVOICE = 135,
    LONGDRAW = 136,
    LONGREACH = 137,
    LOOSESPIKES = 138,
    LURKER = 139,
    MAGICBOUNCE = 140,
    MAGICGUARD = 141,
    MAGICIAN = 142,
    MAGMAARMOR = 143,
    MAGNETPULL = 144,
    MAGNETICFLUX = 145,
    MARVELSCALE = 146,
    MEGALAUNCHER = 147,
    MERCILESS = 148,
    MIMICRY = 149,
    MINUS = 150,
    MIRRORARMOR = 151,
    MISTYDRAIN = 152,
    MISTYSURGE = 153,
    MOLDBREAKER = 154,
    MOODY = 155,
    MOONLITNIGHT = 156,
    MORPHINGSKIN = 157,
    MOTORDRIVE = 158,
    MOUNTAINEER = 159,
    MOXIE = 160,
    MULTISCALE = 161,
    MULTITYPE = 162,
    MUMMY = 163,
    NATURALCURE = 164,
    NEUROFORCE = 165,
    NEUTRALIZINGGAS = 166,
    NOGUARD = 167,
    NORMALIZE = 168,
    OBLIVIOUS = 169,
    OVERCAST = 170,
    OVERCOAT = 171,
    OVERGROW = 172,
    OWNTEMPO = 173,
    PARENTALBOND = 174,
    PASTELVEIL = 175,
    PERISHBODY = 176,
    PERSISTENT = 177,
    PICKPOCKET = 178,
    PICKUP = 179,
    PIXILATE = 180,
    PLUS = 181,
    POISONHEAL = 182,
    POISONPOINT = 183,
    POISONTOUCH = 184,
    POLLUTANTSPILL = 185,
    POWERCONSTRUCT = 186,
    POWEROFALCHEMY = 187,
    POWERSPOT = 188,
    PRANKSTER = 189,
    PRESSURE = 190,
    PRIMORDIALSEA = 191,
    PRISMARMOR = 192,
    PROPELLERTAIL = 193,
    PROTEAN = 194,
    PSIONIC = 195,
    PSYCHICDRAIN = 196,
    PSYCHICSURGE = 197,
    PUNKROCK = 198,
    PUREPOWER = 199,
    QUEENLYMAJESTY = 200,
    QUICKDRAW = 201,
    QUICKFEET = 202,
    RAINDISH = 203,
    RATTLED = 204,
    RECEIVER = 205,
    RECKLESS = 206,
    REFRIGERATE = 207,
    REGENERATOR = 208,
    RESOLUTE = 209,
    RIPEN = 210,
    RIVALRY = 211,
    RKSSYSTEM = 212,
    ROCKHEAD = 213,
    ROUGHSKIN = 214,
    RUNAWAY = 215,
    SANDFORCE = 216,
    SANDRUSH = 217,
    SANDSPIT = 218,
    SANDSTREAM = 219,
    SANDVEIL = 220,
    SAPSIPPER = 221,
    SCHOOLING = 222,
    SCRAPPY = 223,
    SCREENCLEANER = 224,
    SELFLESS = 225,
    SERENEGRACE = 226,
    SHADOWSHIELD = 227,
    SHADOWTAG = 228,
    SHEDSKIN = 229,
    SHEERFORCE = 230,
    SHELLARMOR = 231,
    SHIELDDUST = 232,
    SHIELDSDOWN = 233,
    SIMPLE = 234,
    SINGER = 235,
    SKILLLINK = 236,
    SLOWSTART = 237,
    SLUSHRUSH = 238,
    SNIPER = 239,
    SNOWCLOAK = 240,
    SNOWWARNING = 241,
    SOLARPANEL = 242,
    SOLARPOWER = 243,
    SOLIDROCK = 244,
    SOOTHINGSCENT = 245,
    SOULSEEKER = 246,
    SOULHEART = 247,
    SOUNDPROOF = 248,
    SPEEDBOOST = 249,
    STABLELATICE = 250,
    STAKEOUT = 251,
    STALL = 252,
    STALWART = 253,
    STAMINA = 254,
    STANCECHANGE = 255,
    STATIC = 256,
    STEADFAST = 257,
    STEAMENGINE = 258,
    STEELWORKER = 259,
    STEELYSPIRIT = 260,
    STELLARCORE = 261,
    STENCH = 262,
    STICKYHOLD = 263,
    STORMDRAIN = 264,
    STRONGJAW = 265,
    STURDY = 266,
    SUCTIONCUPS = 267,
    SUPERLUCK = 268,
    SURGESURFER = 269,
    SWAMPPELT = 270,
    SWAMPYSURGE = 271,
    SWARM = 272,
    SWEETVEIL = 273,
    SWIFTSWIM = 274,
    SYMBIOSIS = 275,
    SYNCHRONIZE = 276,
    TANGLEDFEET = 277,
    TANGLINGHAIR = 278,
    TECHNICIAN = 279,
    TELEPATHY = 280,
    TERAVOLT = 281,
    THICKFAT = 282,
    TINTEDLENS = 283,
    TORRENT = 284,
    TOUGHCLAWS = 285,
    TOXICBOOST = 286,
    TRACE = 287,
    TRAILINGMIST = 288,
    TRIAGE = 289,
    TROUGHS = 290,
    TRUANT = 291,
    TURBOBLAZE = 292,
    UNAWARE = 293,
    UNBURDEN = 294,
    UNNERVE = 295,
    UNSEENFIST = 296,
    VICTORYSTAR = 297,
    VIGOROUSROOTS = 298,
    VITALSPIRIT = 299,
    VOLTABSORB = 300,
    WANDERINGSPIRIT = 301,
    WATERABSORB = 302,
    WATERBUBBLE = 303,
    WATERCOMPACTION = 304,
    WATERVEIL = 305,
    WEAKARMOR = 306,
    WHITESMOKE = 307,
    WIMPOUT = 308,
    WONDERGUARD = 309,
    WONDERSKIN = 310,
    ZENMODE = 311,
    ZEPHYR = 312,
}

public enum PokeStat
{
    HP = 0,
    ATK = 1,
    DEF = 2,
    SPE = 3,
    SPATK = 4,
    SPDEF = 5,
    BST = 6
}

public enum PokeEggGroup
{
    NULL = 0,
    AMORPHOUS = 1,
    BUG = 2,
    DITTO = 3,
    DRAGON = 4,
    FAIRY = 5,
    FIELD = 6,
    FLYING = 7,
    GRASS = 8,
    HUMANLIKE = 9,
    MINERAL = 10,
    MONSTER = 11,
    SPACE = 12,
    UNDISCOVERED = 13,
    WATER1 = 14,
    WATER2 = 15,
    WATER3 = 16,
}

public enum PokeGenderRate
{
    Null = 0,
    Genderless = 1,
    AlwaysMale = 2,
    Female25Percent = 3,
    Female50Percent = 4,
    Female75Percent = 5,
    AlwaysFemale = 6,
}

public enum PokeGrowthRate
{
    Null = 0,
    Fast = 1,
    Medium = 2,
    Slow = 3,
    Parabolic = 4,
    Erratic = 5,
    Fluctuating = 6
}

public enum PokeColor
{
    Null = 0,
    White = 1,
    Gray = 2,
    Black = 3,
    Purple = 4,
    Pink = 5,
    Red = 6,
    Orange = 7,
    Yellow = 8,
    Green = 9,
    Blue = 10,
    Brown = 11
}

public enum PokeShape
{
    Null = 0,
    Bipedal = 1,
    BipedalTail = 2,
    Finned = 3,
    Head = 4,
    HeadArms = 5,
    HeadBase = 6,
    HeadLegs = 7,
    Insectoid = 8,
    Multibody = 9,
    Multiped = 10,
    MultiWinged = 11,
    Quadruped = 12,
    Serpentine = 13,
    Winged = 14
}

public enum PokeOrigin
{
    Null = 0,
    Alolan = 1,
    Galarian = 2,
    Hisuian = 3,
    Hoennian = 4,
    Johtonian = 5,
    Kalosite = 6,
    Kantonian =7,
    Liorian = 8,
    Sinnoh = 9
}

public enum MoveCategory
{
    NULL = 0,
    PHYSICAL = 1,
    SPECIAL = 2,
    STATUS = 3
}

public enum MoveTarget
{
    Null = 0,
    None = 1,           //For Counter, Metal Burst, Mirror Coat.
    User = 2,
    NearAlly = 3,       //For Aromatic Mist, Helping Hand and Hold Hands.
    UserOrNearAlly = 4, //For Acupressure.
    UserAndAllies = 5,  //For Aromatherapy, Gear Up, Heal Bell, Life Dew, Magnetic Flux.
    NearFoe = 6,        //For Me First.
    AllNearFoes = 7,    
    RandomNearFoe = 8,  //For Petal Dance, Outrage, Struggle, Thrash, Uproar.
    Foe = 9,
    AllFoes = 10,        //Unused by default.
    NearOther = 11,
    AllNearOthers = 12,
    Other = 13,         //For most Flying-type moves and pulse moves.
    AllBattlers = 14,   //For Flower Shield, Perish Song, Rototiller, Teatime.
    UserSide = 15,      //Affects the side itself rather than any Pokémon.
    FoeSide = 16,       //Affects the side itself rather than any Pokémon. For entry hazards.
    BothSides = 17      //Affects the battle as a whole rather than any Pokémon. For weather, etc.
}

namespace PokeSpreadsheetsToTxt
{
    public class  EnumMethods
    {
        /// <summary>
        /// Iterates through the _enumer and returns true if any of the enums match _text
        /// Otherwise returns false
        /// </summary>
        /// <param name="_text"></param>
        /// <returns>True if the string value matches _text, otherwise false</returns>
        public bool IsA_<T>(List<T> _enumer, string _text)
        {
            var _textEdit = _text.Replace(" ", "");
            for (int i = 0; i < _enumer.Count; i++)
			{
                if (_textEdit == _enumer[i].ToString())
                {
                    return true;
                }
			}
            return false;
        }

        /// <summary>
        /// Iterates through the _enumer of type T and returns the enum that match _text
        /// Otherwise returns default(T)
        /// </summary>
        /// <param name="_text"></param>
        /// <returns>The enum of type T that matches _text, Otherwise default(T)</returns>
        public T ConvertTo_AsEnum<T>(List<T> _enumer, string _text)
        {
            var _textEdit = _text.Replace(" ", "");
            for (int i = 0; i < _enumer.Count; i++)
            {
                if (_textEdit == _enumer[i].ToString())
                {
                    return _enumer[i];
                }
            }
            return default;
        }


        /// <summary>
        /// Iterates through the _enumer of type T and returns the enum of type T as a string that matches _text
        /// Otherwise returns null
        /// </summary>
        /// <param name="_text"></param>
        /// <returns>the enum of type T as a string that matches _text, Otherwise null</returns>
        public string ConvertTo_AsString<T>(List<T> _enumer, string _text)
        {
            var _textEdit = _text.ToUpper().Replace(" ", "");
            for (int i = 0; i < _enumer.Count; i++)
            {
                if (_textEdit == _enumer[i].ToString())
                {
                    return _enumer[i].ToString();
                }
            }
            return null;
        }
    }
}


