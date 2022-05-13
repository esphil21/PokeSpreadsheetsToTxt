using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PokeSpreadsheetsToTxt
{
    public class Pokemon
    {
        private int? DexNumber;

        private string Name;
        private string InternalName;

        private static PokeType? Type1, Type2;
        private Tuple<PokeType?, PokeType?> Types =
            new Tuple<PokeType?, PokeType?>(Type1, Type2);

        private static int? HP, ATK, DEF, SPE, SPATK, SPDEF, BST;
        private Tuple<int?, int?, int?, int?, int?, int?, int?> Stats = 
            new Tuple<int?, int?, int?, int?, int?, int?, int?>(HP, ATK, DEF, SPE, SPATK, SPDEF, BST);

        private PokeGenderRate? GenderRate;
        private PokeGrowthRate? GrowthRate;

        private int? BaseEXP;

        private static int? ev_HP, ev_ATK, ev_DEF, ev_SPATK, ev_SPDEF, ev_SPE;
        private Tuple<int?, int?, int?, int?, int?, int?> EffortValues =
            new Tuple<int?, int?, int?, int?, int?, int?>(ev_HP, ev_ATK, ev_DEF, ev_SPATK, ev_SPDEF, ev_SPE);

        private int? Rareness, Happiness;

        private static PokeAbility? Ability1, Ability2, HiddenAbility;
        private Tuple<PokeAbility?, PokeAbility?, PokeAbility?> Abilities = 
            new Tuple<PokeAbility?, PokeAbility?, PokeAbility?>(Ability1, Ability2, HiddenAbility);

        private string LearnMoves, TutorMoves, EggMoves, TM_Moves, TR_Moves;

        private static PokeEggGroup? EggGroup1, EggGroup2;
        private Tuple<PokeEggGroup?, PokeEggGroup?> EggGroups =
            new Tuple<PokeEggGroup?, PokeEggGroup?>(EggGroup1, EggGroup2);

        private int? StepsToHatch;
        private double? Height, Weight;

        private PokeColor? Color;

        private PokeShape? Shape;

        private string Kind;

        private string DexEntry;

        private bool? HasForms;
        private List<string> FormNames;

        private int? Generation;

        // 1 = common, 2 = uncommon, 3 = rare
        private static string WildItem1, WildItem2, WildItem3;
        private Tuple<string, string, string> WildItems =
            new Tuple<string, string, string>(WildItem1, WildItem2, WildItem3);

        // POSITIONING
        private int? BattlerPlayerX, BattlerPlayerY, BattlerEnemyX, BattlerEnemyY, BattlerShadowX, BattlerShadowSize;

        private string Evolutions;

        // EXTRAS
        private bool? Altered, Starter, Guardian, PostGame;


        // The following have no accessors
        public const int DEX_NUM_MAX = 1002;
        public const int NUM_GENS = 9;
        public const int NUM_STATS = 7;
        public const int NUM_EVs = 6;
        private EnumMethods enumer = new EnumMethods();

        private static List<PokeType> PokeTypeArr = new List<PokeType> { PokeType.NULL, PokeType.NORMAL, PokeType.FIGHTING,
            PokeType.FLYING, PokeType.POISON, PokeType.GROUND, PokeType.ROCK, PokeType.BUG, PokeType.GHOST, PokeType.STEEL,
            PokeType.FIRE, PokeType.WATER, PokeType.GRASS, PokeType.ELECTRIC, PokeType.PSYCHIC, PokeType.ICE, PokeType.DRAGON,
            PokeType.DARK, PokeType.FAIRY, PokeType.STAR, PokeType.SOUND };

        private static List<PokeEggGroup> PokeEggGroupArr = new List<PokeEggGroup> { PokeEggGroup.NULL, PokeEggGroup.AMORPHOUS,
            PokeEggGroup.BUG, PokeEggGroup.DITTO, PokeEggGroup.DRAGON, PokeEggGroup.FIELD, PokeEggGroup.FAIRY, PokeEggGroup.FLYING,
            PokeEggGroup.GRASS, PokeEggGroup.HUMANLIKE, PokeEggGroup.MINERAL, PokeEggGroup.MONSTER, PokeEggGroup.SPACE,
            PokeEggGroup.UNDISCOVERED, PokeEggGroup.WATER1, PokeEggGroup.WATER2, PokeEggGroup.WATER3 };

        private static List<PokeAbility> PokeAbilityArr = new List<PokeAbility> { PokeAbility.NULL, PokeAbility.ADAPTABILITY,
            PokeAbility.AERILATE, PokeAbility.AFTERMATH, PokeAbility.AIRLOCK, PokeAbility.ALLOY, PokeAbility.AMPLIFIER,
            PokeAbility.ANALYTIC, PokeAbility.ANGERPOINT, PokeAbility.ANTICIPATION, PokeAbility.ARENATRAP, PokeAbility.AROMAVEIL,
            PokeAbility.ASTRONOMER, PokeAbility.AURABOOST, PokeAbility.AURABREAK, PokeAbility.BADDREAMS, PokeAbility.BALLFETCH,
            PokeAbility.BATTERY, PokeAbility.BATTLEARMOR, PokeAbility.BATTLEBOND, PokeAbility.BEASTBOOST, PokeAbility.BERSERK,
            PokeAbility.BIGPECKS, PokeAbility.BLAZE, PokeAbility.BULLETPROOF, PokeAbility.BURNBRIGHT, PokeAbility.CACOPHONY,
            PokeAbility.CHARGEDSHOT, PokeAbility.CHEEKPOUCH, PokeAbility.CHILLINGAURA, PokeAbility.CHLOROPHYLL, PokeAbility.CLEARBODY,
            PokeAbility.CLOUDNINE, PokeAbility.COLORCHANGE, PokeAbility.COMATOSE, PokeAbility.COMPETITIVE, PokeAbility.COMPOUNDEYES,
            PokeAbility.CONTRARY, PokeAbility.CORROSION, PokeAbility.COSMICSIPHON, PokeAbility.COSMICSURGE, PokeAbility.COTTONDOWN,
            PokeAbility.CURIOUSMEDICINE, PokeAbility.CURSEDBODY, PokeAbility.CUTECHARM, PokeAbility.DAMP, PokeAbility.DANCER,
            PokeAbility.DARKAURA, PokeAbility.DAUNTLESSSHIELD, PokeAbility.DAZZLING, PokeAbility.DEFEATIST, PokeAbility.DEFIANT,
            PokeAbility.DELTASTREAM, PokeAbility.DESOLATELAND, PokeAbility.DISGUISE, PokeAbility.DOWNLOAD, PokeAbility.DRACONICSPIRIT,
            PokeAbility.DRIZZLE, PokeAbility.DROPANCHOR, PokeAbility.DROUGHT, PokeAbility.DRYSKIN, PokeAbility.EARLYBIRD,
            PokeAbility.EFFECTSPORE, PokeAbility.ELECTRICSURGE, PokeAbility.ELECTROVORE, PokeAbility.EMERGENCYEXIT,
            PokeAbility.ENERGYSHIELD, PokeAbility.EVENTHORIZON, PokeAbility.FAIRYAURA, PokeAbility.FEATHERDOWN, PokeAbility.FIGHTINGFIT,
            PokeAbility.FILTER, PokeAbility.FLAMEBODY, PokeAbility.FLAREBOOST, PokeAbility.FLASHFIRE, PokeAbility.FLOWERGIFT,
            PokeAbility.FLOWERVEIL, PokeAbility.FLUFFY, PokeAbility.FLYINGACE, PokeAbility.FORECAST, PokeAbility.FOREWARN,
            PokeAbility.FRIENDGUARD, PokeAbility.FRISK, PokeAbility.FULLMETALBODY, PokeAbility.FURCOAT, PokeAbility.GALEWINGS,
            PokeAbility.GALVANIZE, PokeAbility.GLUTTONY, PokeAbility.GOOEY, PokeAbility.GORILLATACTICS, PokeAbility.GRASSPELT,
            PokeAbility.GRASSYSURGE, PokeAbility.GRAVITON, PokeAbility.GULPMISSILE, PokeAbility.GUTS, PokeAbility.HARVEST,
            PokeAbility.HEALER, PokeAbility.HEATPROOF, PokeAbility.HEAVYMETAL, PokeAbility.HERBIVORE, PokeAbility.HONEYGATHER,
            PokeAbility.HUGEPOWER, PokeAbility.HUNGERSWITCH, PokeAbility.HUSTLE, PokeAbility.HYDRATION, PokeAbility.HYPERCUTTER,
            PokeAbility.ICEBODY, PokeAbility.ICEFACE, PokeAbility.ICESCALES, PokeAbility.ILLUMINATE, PokeAbility.ILLUSION,
            PokeAbility.IMMUNITY, PokeAbility.IMPOSTER, PokeAbility.INFILTRATOR, PokeAbility.INNARDSOUT, PokeAbility.INNERFOCUS,
            PokeAbility.INNERRHYTHM, PokeAbility.INSOMNIA, PokeAbility.INTANGIBLE, PokeAbility.INTERSTELLAR, PokeAbility.INTIMIDATE,
            PokeAbility.INTREPIDSWORD, PokeAbility.IRONBARBS, PokeAbility.IRONFIST, PokeAbility.JETSTREAM, PokeAbility.JUSTIFIED,
            PokeAbility.KEENEYE, PokeAbility.KLUTZ, PokeAbility.LEAFGUARD, PokeAbility.LEVITATE, PokeAbility.LIBERO, PokeAbility.LIGHTMETAL,
            PokeAbility.LIGHTNINGROD, PokeAbility.LIMBER, PokeAbility.LIQUIDOOZE, PokeAbility.LIQUIDVOICE, PokeAbility.LONGDRAW,
            PokeAbility.LONGREACH, PokeAbility.LOOSESPIKES, PokeAbility.LURKER, PokeAbility.MAGICBOUNCE, PokeAbility.MAGICGUARD,
            PokeAbility.MAGICIAN, PokeAbility.MAGMAARMOR, PokeAbility.MAGNETPULL, PokeAbility.MAGNETICFLUX, PokeAbility.MARVELSCALE,
            PokeAbility.MEGALAUNCHER, PokeAbility.MERCILESS, PokeAbility.MIMICRY, PokeAbility.MINUS, PokeAbility.MIRRORARMOR,
            PokeAbility.MISTYDRAIN, PokeAbility.MISTYSURGE, PokeAbility.MOLDBREAKER, PokeAbility.MOODY, PokeAbility.MOONLITNIGHT,
            PokeAbility.MORPHINGSKIN, PokeAbility.MOTORDRIVE, PokeAbility.MOUNTAINEER, PokeAbility.MOXIE, PokeAbility.MULTISCALE,
            PokeAbility.MULTITYPE, PokeAbility.MUMMY, PokeAbility.NATURALCURE, PokeAbility.NEUROFORCE, PokeAbility.NEUTRALIZINGGAS,
            PokeAbility.NOGUARD, PokeAbility.NORMALIZE, PokeAbility.OBLIVIOUS, PokeAbility.OVERCAST, PokeAbility.OVERCOAT,
            PokeAbility.OVERGROW, PokeAbility.OWNTEMPO, PokeAbility.PARENTALBOND, PokeAbility.PASTELVEIL, PokeAbility.PERISHBODY,
            PokeAbility.PERSISTENT, PokeAbility.PICKPOCKET, PokeAbility.PICKUP, PokeAbility.PIXILATE, PokeAbility.PLUS,
            PokeAbility.POISONHEAL, PokeAbility.POISONPOINT, PokeAbility.POISONTOUCH, PokeAbility.POLLUTANTSPILL,
            PokeAbility.POWERCONSTRUCT, PokeAbility.POWEROFALCHEMY, PokeAbility.POWERSPOT, PokeAbility.PRANKSTER,
            PokeAbility.PRESSURE, PokeAbility.PRIMORDIALSEA, PokeAbility.PRISMARMOR, PokeAbility.PROPELLERTAIL, PokeAbility.PROTEAN,
            PokeAbility.PSIONIC, PokeAbility.PSYCHICDRAIN, PokeAbility.PSYCHICSURGE, PokeAbility.PUNKROCK, PokeAbility.PUREPOWER,
            PokeAbility.QUEENLYMAJESTY, PokeAbility.QUICKDRAW, PokeAbility.QUICKFEET, PokeAbility.RAINDISH, PokeAbility.RATTLED,
            PokeAbility.RECEIVER, PokeAbility.RECKLESS, PokeAbility.REFRIGERATE, PokeAbility.REGENERATOR, PokeAbility.RESOLUTE,
            PokeAbility.RIPEN, PokeAbility.RIVALRY, PokeAbility.RKSSYSTEM, PokeAbility.ROCKHEAD, PokeAbility.ROUGHSKIN, PokeAbility.RUNAWAY,
            PokeAbility.SANDFORCE, PokeAbility.SANDRUSH, PokeAbility.SANDSPIT, PokeAbility.SANDSTREAM, PokeAbility.SANDVEIL,
            PokeAbility.SAPSIPPER, PokeAbility.SCHOOLING, PokeAbility.SCRAPPY, PokeAbility.SCREENCLEANER, PokeAbility.SELFLESS,
            PokeAbility.SERENEGRACE, PokeAbility.SHADOWSHIELD, PokeAbility.SHADOWTAG, PokeAbility.SHEDSKIN, PokeAbility.SHEERFORCE,
            PokeAbility.SHELLARMOR, PokeAbility.SHIELDDUST, PokeAbility.SHIELDSDOWN, PokeAbility.SIMPLE, PokeAbility.SINGER,
            PokeAbility.SKILLLINK, PokeAbility.SLOWSTART, PokeAbility.SLUSHRUSH, PokeAbility.SNIPER, PokeAbility.SNOWCLOAK,
            PokeAbility.SNOWWARNING, PokeAbility.SOLARPANEL, PokeAbility.SOLARPOWER, PokeAbility.SOLIDROCK, PokeAbility.SOOTHINGSCENT,
            PokeAbility.SOULSEEKER, PokeAbility.SOULHEART, PokeAbility.SOUNDPROOF, PokeAbility.SPEEDBOOST, PokeAbility.STABLELATICE,
            PokeAbility.STAKEOUT, PokeAbility.STALL, PokeAbility.STALWART, PokeAbility.STAMINA, PokeAbility.STANCECHANGE,
            PokeAbility.STATIC, PokeAbility.STEADFAST, PokeAbility.STEAMENGINE, PokeAbility.STEELWORKER, PokeAbility.STEELYSPIRIT,
            PokeAbility.STELLARCORE, PokeAbility.STENCH, PokeAbility.STICKYHOLD, PokeAbility.STORMDRAIN, PokeAbility.STRONGJAW,
            PokeAbility.STURDY, PokeAbility.SUCTIONCUPS, PokeAbility.SUPERLUCK, PokeAbility.SURGESURFER, PokeAbility.SWAMPPELT,
            PokeAbility.SWAMPYSURGE, PokeAbility.SWARM, PokeAbility.SWEETVEIL, PokeAbility.SWIFTSWIM, PokeAbility.SYMBIOSIS,
            PokeAbility.SYNCHRONIZE, PokeAbility.TANGLEDFEET, PokeAbility.TANGLINGHAIR, PokeAbility.TECHNICIAN, PokeAbility.TELEPATHY,
            PokeAbility.TERAVOLT, PokeAbility.THICKFAT, PokeAbility.TINTEDLENS, PokeAbility.TORRENT, PokeAbility.TOUGHCLAWS,
            PokeAbility.TOXICBOOST, PokeAbility.TRACE, PokeAbility.TRAILINGMIST, PokeAbility.TRIAGE, PokeAbility.TROUGHS,
            PokeAbility.TRUANT, PokeAbility.TURBOBLAZE, PokeAbility.UNAWARE, PokeAbility.UNBURDEN, PokeAbility.UNNERVE, PokeAbility.UNSEENFIST,
            PokeAbility.VICTORYSTAR, PokeAbility.VIGOROUSROOTS, PokeAbility.VITALSPIRIT, PokeAbility.VOLTABSORB, PokeAbility.WANDERINGSPIRIT,
            PokeAbility.WATERABSORB, PokeAbility.WATERBUBBLE, PokeAbility.WATERCOMPACTION, PokeAbility.WATERVEIL, PokeAbility.WEAKARMOR,
            PokeAbility.WHITESMOKE, PokeAbility.WIMPOUT, PokeAbility.WONDERGUARD, PokeAbility.WONDERSKIN, PokeAbility.ZENMODE,
            PokeAbility.ZEPHYR };

        private static List<PokeGenderRate> PokeGenderRateArr = new List<PokeGenderRate>() { PokeGenderRate.Null, PokeGenderRate.Genderless,
            PokeGenderRate.AlwaysMale, PokeGenderRate.Female25Percent, PokeGenderRate.Female50Percent, PokeGenderRate.Female75Percent,
            PokeGenderRate.AlwaysFemale };

        private static List<PokeGrowthRate> PokeGrowthRateArr = new List<PokeGrowthRate>() { PokeGrowthRate.Null, PokeGrowthRate.Fast,
            PokeGrowthRate.Medium, PokeGrowthRate.Slow, PokeGrowthRate.Parabolic, PokeGrowthRate.Erratic, PokeGrowthRate.Fluctuating };

        private static List<PokeColor> PokeColorArr = new List<PokeColor>() { PokeColor.Null, PokeColor.White, PokeColor.Gray, PokeColor.Black,
            PokeColor.Purple, PokeColor.Pink, PokeColor.Red, PokeColor.Orange, PokeColor.Yellow, PokeColor.Green, PokeColor.Blue, PokeColor.Brown };

        private static List<PokeShape> PokeShapeArr = new List<PokeShape>() { PokeShape.Null, PokeShape.Bipedal, PokeShape.BipedalTail, PokeShape.Finned,
            PokeShape.Head, PokeShape.HeadArms, PokeShape.HeadBase, PokeShape.HeadLegs, PokeShape.Insectoid, PokeShape.Multibody, PokeShape.Multiped,
            PokeShape.MultiWinged, PokeShape.Quadruped, PokeShape.Serpentine, PokeShape.Winged };

        /// <summary>
        /// Constructor, sets all values to null to start.
        /// </summary>
        public Pokemon()
        {
            DexNumber = null;
            Name = null;
            InternalName = null;

            Type1 = null; Type2 = null;
            Types = null;

            HP = null; ATK = null; DEF = null; SPE = null; SPATK = null; SPDEF = null; BST = null;
            Stats = null;

            GenderRate = null;
            GrowthRate = null;
            BaseEXP = null;
            EffortValues = null;
            Rareness = null;
            Happiness = null;

            Ability1 = null; Ability2 = null; HiddenAbility = null;
            Abilities = null;

            LearnMoves = null; EggMoves = null; TM_Moves = null; TR_Moves = null; TutorMoves = null;

            EggGroup1 = null; EggGroup2 = null;
            EggGroups = null;

            StepsToHatch = null;
            Height = null;
            Weight = null;
            Kind = null;
            DexEntry = null;
            HasForms = null;
            FormNames = null;
            Generation = null;

            WildItem1 = null; WildItem2 = null; WildItem3 = null;
            WildItems = null;

            Color = null;
            Shape = null;

            Altered = null;
            Starter = null;
            Guardian = null;
            PostGame = null;

            BattlerPlayerX = null; BattlerPlayerY = null;
            BattlerEnemyX = null; BattlerEnemyY = null;
            BattlerShadowX = null; 
            BattlerShadowSize = null;
        }

        #region HelperMethods
        /// <summary>
        /// Verifies _name is a valid name by checking if:
        /// </summary>
        /// <param name="_name"></param>
        /// <returns>True if the above characteristics are met</returns>
        public bool IsValidName(string _name)
        {
            if (_name != null || _name != String.Empty)
            {
                /*TODO:*/
                //_name = _name.Trim();

                //var letters = regi.Letter.Matches(_name);
                //var numbers = regi.Number.Matches(_name);
                //var specials = regi.Special.Matches(_name);
                //var exceptedSpecials = regi.ExceptedSpecials.Matches(_name);
                //var spaces = regi.Spaces.Matches(_name);

                //if (letters.Count >= 4 && numbers.Count == 0 && specials.Count >= 0 && exceptedSpecials.Count == 1 && spaces.Count >= 1)
                //{
                //    return true;
                //}
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifies _name is a valid name by checking if:
        /// </summary>
        /// <param name="_name"></param>
        /// <returns>True if the above characteristics are met</returns>
        public bool IsValidFormName(string _name)
        {
            if (_name != null || _name != String.Empty)
            {
                /*TODO:*/
                //_name = _name.Trim();

                //var letters = regi.Letter.Matches(_name);
                //var numbers = regi.Number.Matches(_name);
                //var specials = regi.Special.Matches(_name);
                //var dashes = regi.Dash.Matches(_name);
                //var spaces = regi.Spaces.Matches(_name);

                //if (letters.Count >= 4 && numbers.Count == 0 && specials.Count >= 1 && dashes.Count == 1 && spaces.Count == 0)
                //{
                //    return true;
                //}
                return false;
            }
            return false;
        }
        #endregion HelperMethods

        #region DEXNUMBER
        /// <summary>
        /// Returns this.DexNumber
        /// </summary>
        /// <returns>this.DexNumber</returns>
        public int? GetDexNumber()
        {
            return DexNumber;
        }

        /// <summary>
        /// If _num is between 0 and DEX_NUM_MAX, sets this.DexNumber to _num and returns true, otherwise returns false
        /// </summary>
        /// <param name="_num"></param>
        /// <returns>True if the method successfully set this.DexNumber, otherwise false</returns>
        public bool SetDexNumber(int? _num)
        {
            if (_num > 0 && _num <= DEX_NUM_MAX)
            {
                DexNumber = _num;
                return true;
            }
            return false;
        }
        #endregion DEXNUMBER

        #region NAMES
        /// <summary>
        /// Returns the value of this.Name
        /// </summary>
        /// <returns> the string, this.Name </returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// If _name is a valid name, sets this.Name to _name and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_name"></param>
        /// <returns>True if the method successfully set this.Name, otherwise false</returns>
        public bool SetName(string _name)
        {
            if (IsValidName(_name))
            {
                Name = _name;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the value of this.InternalName
        /// </summary>
        /// <returns> the string, this.InternalName </returns>
        public string GetInternalName()
        {
            return InternalName;
        }

        /// <summary>
        /// If _nameinternal is a valid name, sets this.InternalName to _nameinternal and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_internalname"></param>
        /// <returns>True if the method successfully set this.NameInternal, otherwise false</returns>
        public bool SetInternalName(string _internalname)
        {
            if (IsValidName(_internalname))
            {
                InternalName = _internalname;
                return true;
            }
            return false;
        }
        #endregion NAMES

        #region TYPES
        /// <summary>
        /// Returns this.Types
        /// </summary>
        /// <returns>this.Types</returns>
        public Tuple<PokeType?, PokeType?> GetTypes()
        {
            return Types;
        }

        /// <summary>
        /// Returns the type at _index from this.Types
        /// if the _index is not set to 0 or 1 returns null
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <returns>The type at _index from this.Types</returns>
        public string GetType(int _index)
        {
            switch (_index)
            {
                case 0: return Types.Item1.ToString();
                case 1: return Types.Item2.ToString();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns true if either of the this.Types equals _type
        /// </summary>
        /// <param name="_type"></param>
        /// <returns>True if either of this.Types equals the _type</returns>
        public bool HasType(string _type)
        {
            if (enumer.IsA_(PokeTypeArr, _type))
            {
                if (nameof(Types.Item1) == _type || nameof(Types.Item2) == _type)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If _type1 and _type2 are valid PokeTypes, then sets this.Types to _type1 and _type2 and returns true.
        /// otherwise returns false
        /// </summary>
        /// <param name="_type1"></param>
        /// <param name="_type2"></param>
        /// <returns>True if the method successfully set this.Types. otherwise false</returns>
        public bool SetTypes(string _type1, string _type2)
        {
            if (enumer.IsA_(PokeTypeArr, _type1.ToUpper()) && enumer.IsA_(PokeTypeArr, _type2.ToUpper()))
            {
                Type1 = enumer.ConvertTo_AsEnum(PokeTypeArr, _type1.ToUpper());
                Type2 = enumer.ConvertTo_AsEnum(PokeTypeArr, _type2.ToUpper());

                Types = new Tuple<PokeType?, PokeType?>(Type1, Type2);
                return true;
            }
            return false;
        }

        /// <summary>
        /// If _type is a valid PokeType sets the Type at _index in this.Types to _type and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <param name="_type"></param>
        /// <returns>True if the method successfully set this.Types at _index to _type. otherwise false</returns>
        public bool SetType(int _index, string _type)
        {
            if (enumer.IsA_(PokeTypeArr, _type.ToUpper()))
            {
                PokeType? poke_type = enumer.ConvertTo_AsEnum(PokeTypeArr, _type.ToUpper());

                switch (_index)
                {
                    case 0: Type1 = poke_type; break;
                    case 1: Type2 = poke_type; break;
                    default:
                        return false;
                }

                Types = new Tuple<PokeType?, PokeType?>(Type1, Type2);
                return true;
            }
            return false;
        }
        #endregion TYPES

        #region STATS
        /// <summary>
        /// Returns this.Stats
        /// </summary>
        /// <returns>this.Stats</returns>
        public Tuple<int?, int?, int?, int?, int?, int?, int?> GetStats()
        {
        return Stats;
        }

        /// <summary>
        /// Returns the stat at _index from this.Stats
        /// if the _index is not set to 0:6 returns -1
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <returns>The stat at _index from this.Stats</returns>
        public int? GetStat(int _index)
        {
            switch (_index)
            {
                case 0: return Stats.Item1; // HP
                case 1: return Stats.Item2; // ATK
                case 2: return Stats.Item3; // DEF
                case 3: return Stats.Item4; // SPE
                case 4: return Stats.Item5; // SP_ATK
                case 5: return Stats.Item6; // SP_DEF
                case 6: return Stats.Item7; // BST
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Sets all stats if all the parameters are greater than 0
        /// Then BST is updated and returns true
        /// false otherwise
        /// </summary>
        /// <param name="_hp"></param>
        /// <param name="_atk"></param>
        /// <param name="_def"></param>
        /// <param name="_spe"></param>
        /// <param name="_spatk"></param>
        /// <param name="_spdef"></param>
        /// <returns>True if the method successfully set each Stat in this.Stats</returns>
        public bool SetStats(int _hp, int _atk, int _def, int _spe, int _spatk, int _spdef)
        {
            if (_hp > 0 || _atk > 0 || _def > 0 || _spe > 0 || _spatk > 0 || _spdef > 0 )
            {
                HP = _hp;
                ATK = _atk;
                DEF = _def;
                SPE = _spe;
                SPATK = _spatk;
                SPDEF = _spdef;

                // Update BST
                BST = HP + ATK + DEF + SPE + SPATK + SPDEF;

                Stats = new Tuple<int?, int?, int?, int?, int?, int?, int?>(HP, ATK, DEF, SPE, SPATK, SPDEF, BST);
                return true;
            }
            return false;
        }

        /// <summary>
        /// sets the stat at _index in this.Stats if _stat is greater than 0
        /// Then BST is updated and returns true
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <param name="_stat"></param>
        /// <returns>True if the method successfully set this.Stats at _index to _stat. otherwise false</returns>
        public bool SetStat(int _index, int _stat)
        {
            if (_stat > 0)
            {
                switch (_index)
                {
                    case 0: HP = _stat; break;
                    case 1: ATK = _stat; break;
                    case 2: DEF = _stat; break;
                    case 3: SPE = _stat; break;
                    case 4: SPATK = _stat; break;
                    case 5: SPDEF = _stat; break;
                    default:
                        return false;
                }

                // Update BST
                BST = HP + ATK + DEF + SPE + SPATK + SPDEF;

                Stats = new Tuple<int?, int?, int?, int?, int?, int?, int?>(HP, ATK, DEF, SPE, SPATK, SPDEF, BST);
                return true;
            }
            return false;
        }
        #endregion STATS

        #region GENDERRATE
        /// <summary>
        /// Returns this.GenderRate
        /// </summary>
        /// <returns>this.GenderRate</returns>
        public PokeGenderRate? GetGenderRate()
        {
            return GenderRate;
        }

        /// <summary>
        /// If _rate is a valid PokeGenderRate sets this.GenderRate to _rate and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_rate"></param>
        /// <returns>True if the method successfully set this.GenderRate to _rate. otherwise false</returns>
        public bool SetGenderRate(string _rate)
        {
            if (enumer.IsA_(PokeGenderRateArr, _rate))
            {
                PokeGenderRate? gender_rate = enumer.ConvertTo_AsEnum(PokeGenderRateArr, _rate);

                GenderRate = gender_rate;
                return true;
            }
            return false;
        }
        #endregion GENDERRATE

        #region GROWTHRATE
        /// <summary>
        /// Returns this.GrowthRate
        /// </summary>
        /// <returns>this.GrowthRate</returns>
        public PokeGrowthRate? GetGrowthRate()
        {
            return GrowthRate;
        }

        /// <summary>
        /// If _rate is a valid PokeGrowthRate sets this.GrowthRate to _rate and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_rate"></param>
        /// <returns>True if the method successfully set this.GrowthRate to _rate. otherwise false</returns>
        public bool SetGrowthRate(string _rate)
        {
            if (enumer.IsA_(PokeGrowthRateArr, _rate))
            {
                PokeGrowthRate? growth_rate = enumer.ConvertTo_AsEnum(PokeGrowthRateArr, _rate);

                GrowthRate = growth_rate;
                return true;
            }
            return false;
        }
        #endregion GROWTHRATE

        #region BASE_EXP
        /// <summary>
        /// Returns this.BaseEXP
        /// </summary>
        /// <returns>this.BaseEXP</returns>
        public int? GetBaseEXP()
        {
            return BaseEXP;
        }

        /// <summary>
        /// If _value is greater than 0, sets this.BaseEXP to _value and returns true
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.BaseEXP to _value. otherwise false</returns>
        public bool SetBaseEXP(int? _value)
        {
            if (_value != null && _value > 0)
            {
                BaseEXP = _value;
                return true;
            }
            return false;
        }
        #endregion BASE_EXP

        #region EVs
        /// <summary>
        /// Returns this.EffortValues
        /// </summary>
        /// <returns>this.EffortValues</returns>
        public Tuple<int?, int?, int?, int?, int?, int?> GetEffortPoints()
        {
            return EffortValues;
        }

        /// <summary>
        /// Returns this.EffortValues as a string (remove the parameter if you want this.EffortValues to be returned as a Tuple)
        /// </summary>
        /// <param name="asString">default = true, remove if you want this.EffortValues to be returned as a Tuple</param>
        /// <returns>Returns this.EffortValues as a string</returns>
        public string GetEffortPoints(bool asString = true)
        {
            string temp_evs = "";
            for (int i = 0; i < NUM_EVs; i++)
            {
                switch (i)
                {
                    case 0: temp_evs += EffortValues.Item1.ToString() + ','; break;
                    case 1: temp_evs += EffortValues.Item2.ToString() + ','; break;
                    case 2: temp_evs += EffortValues.Item3.ToString() + ','; break;
                    case 3: temp_evs += EffortValues.Item4.ToString() + ','; break;
                    case 4: temp_evs += EffortValues.Item5.ToString() + ','; break;
                    case 5: temp_evs += EffortValues.Item6.ToString(); break;
                }
            }
            return temp_evs;
        }

        /// <summary>
        /// Returns the EV at _index from this.EffortValues
        /// if the _index is not set to 0:5 returns -1
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <returns>The EV at _index from this.EffortValues</returns>
        public int? GetEffortValue(int _index)
        {
            switch (_index)
            {
                case 0: return EffortValues.Item1; // ev_HP
                case 1: return EffortValues.Item2; // ev_ATK
                case 2: return EffortValues.Item3; // ev_DEF
                case 3: return EffortValues.Item4; // ev_SPE
                case 4: return EffortValues.Item5; // ev_SP_ATK
                case 5: return EffortValues.Item6; // ev_SP_DEF
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Sets all EVs if all the parameters are greater than 0 and returns true
        /// </summary>
        /// <param name="ev_hp"></param>
        /// <param name="ev_atk"></param>
        /// <param name="ev_def"></param>
        /// <param name="ev_spe"></param>
        /// <param name="ev_spatk"></param>
        /// <param name="ev_spdef"></param>
        /// <returns>True if the method successfully set each EV in this.EffortValues</returns>
        public bool SetEffortValues(int ev_hp, int ev_atk, int ev_def, int ev_spe, int ev_spatk, int ev_spdef)
        {
            if (ev_hp >= 0 || ev_atk >= 0 || ev_def >= 0 || ev_spe >= 0 || ev_spatk >= 0 || ev_spdef >= 0)
            {
                ev_HP = ev_hp;
                ev_ATK = ev_atk;
                ev_DEF = ev_def;
                ev_SPE = ev_spe;
                ev_SPATK = ev_spatk;
                ev_SPDEF = ev_spdef;

                // verifiy total is greater than 0 and less than 4
                int? total = ev_HP + ev_ATK + ev_DEF + ev_SPE + ev_SPATK + ev_SPDEF;

                if (total > 0 && total < 4)
                {
                    EffortValues = new Tuple<int?, int?, int?, int?, int?, int?>(ev_HP, ev_ATK, ev_DEF, ev_SPE, ev_SPATK, ev_SPDEF);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If the _evs string is formated correctly and its sum is between 1 and 3 (inclusive), sets all EVs and returns true
        /// </summary>
        /// <param name="_evs">string in the format "0,0,0,0,0,0"</param>
        /// <returns>True if the method successfully set each EV in this.EffortValues</returns>
        public bool SetEffortValues(string _evs)
        {
            if (_evs.Length == 11)
            {
                List<int> temp_evs = new List<int> ();
                for (int i = 0; i < _evs.Length; i = i + 2)
                {
                    if (int.TryParse(_evs[i].ToString(), out int _ev)) 
                    {
                        temp_evs.Add(_ev); 
                    } 
                    else 
                    {
                        return false; 
                    }
                }

                int total = 0;
                foreach (var temp_ev in temp_evs)
                {
                    total += temp_ev;
                }
                
                // verifiy total is between 1 and 3 inclusive
                if (total > 0 && total < 4)
                {
                    for (int i = 0; i < temp_evs.Count; i++)
                    {
                        switch (i)
                        {
                            case 0: ev_HP = temp_evs[i]; break;
                            case 1: ev_ATK = temp_evs[i]; break;
                            case 2: ev_DEF = temp_evs[i]; break;
                            case 3: ev_SPE = temp_evs[i]; break;
                            case 4: ev_SPATK = temp_evs[i]; break;
                            case 5: ev_SPDEF = temp_evs[i]; break;
                        }
                    }

                    EffortValues = new Tuple<int?, int?, int?, int?, int?, int?>(ev_HP, ev_ATK, ev_DEF, ev_SPE, ev_SPATK, ev_SPDEF);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// sets the stat at _index in this.Stats if _value is greater than 0
        /// Then BST is updated and returns true
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.Stats at _index to _value. otherwise false</returns>
        public bool SetEffortValue(int _index, int _value)
        {
            if (_value >= 0)
            {
                switch (_index)
                {
                    case 0: ev_HP = _value; break;
                    case 1: ev_ATK = _value; break;
                    case 2: ev_DEF = _value; break;
                    case 3: ev_SPE = _value; break;
                    case 4: ev_SPATK = _value; break;
                    case 5: ev_SPDEF = _value; break;
                    default:
                        return false;
                }

                // verifiy total is greater than 0 and less than 4
                int? total = ev_HP + ev_ATK + ev_DEF + ev_SPE + ev_SPATK + ev_SPDEF;

                if (total > 0 && total < 4)
                {
                    EffortValues = new Tuple<int?, int?, int?, int?, int?, int?>(ev_HP, ev_ATK, ev_DEF, ev_SPE, ev_SPATK, ev_SPDEF);
                    return true;
                }
            }
            return false;
        }
        #endregion EVs

        #region RARENESS
        /// <summary>
        /// Returns this.Rareness
        /// </summary>
        /// <returns>this.Rareness</returns>
        public int? GetRareness()
        {
            return Rareness;
        }

        /// <summary>
        /// If _value is greater than 0, sets this.Rareness to _value and returns true
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.Rareness to _value. otherwise false</returns>
        public bool SetRareness(int? _value)
        {
            if (_value != null && _value > 0)
            {
                Rareness = _value;
                return true;
            }
            return false;
        }
        #endregion RARENESS

        #region HAPPINESS
        /// <summary>
        /// Returns this.Happiness
        /// </summary>
        /// <returns>this.Happiness</returns>
        public int? GetHappiness()
        {
            return Happiness;
        }

        /// <summary>
        /// If _value is greater than 0, sets this.Happiness to _value and returns true
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.Happiness to _value. otherwise false</returns>
        public bool SetHappiness(int? _value)
        {
            if (_value != null && _value > 0)
            {
                Happiness = _value;
                return true;
            }
            return false;
        }
        #endregion HAPPINESS

        #region ABILITIES
        /// <summary>
        /// Returns this.Abilities
        /// </summary>
        /// <returns>this.Abilities</returns>
        public Tuple<PokeAbility?, PokeAbility?, PokeAbility?> GetAbilities()
        {
            return Abilities;
        }

        /// <summary>
        /// Returns the ability at _index from this.Abilities
        /// if the _index is not set to 0:2 returns null
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <returns>The ability at _index from this.Abilities</returns>
        public string GetAbility(int _index)
        {
            switch (_index)
            {
                case 0: return Abilities.Item1.ToString();
                case 1: return Abilities.Item2.ToString();
                case 2: return Abilities.Item3.ToString(); // HiddenAbility
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns true if any of this.Abilities equals _ability
        /// </summary>
        /// <param name="_ability"></param>
        /// <returns>True if either of this.Abilities equals the _ability</returns>
        public bool HasAbility(string _ability)
        {
            if (enumer.IsA_(PokeAbilityArr, _ability.ToUpper()))
            {
                if (nameof(Abilities.Item1) == _ability || nameof(Abilities.Item2) == _ability || nameof(Abilities.Item3) == _ability)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If _ability1, _ability2, and _ability3 are valid abilities, then sets this.Abilities to
        /// _ability1, _ability2, and _ability3 and returns true. otherwise returns false
        /// </summary>
        /// <param name="_ability1"></param>
        /// <param name="_ability2"></param>
        /// <param name="_ability3"></param>
        /// <returns>True if the method successfully set this.Abilities at _index to _ability. otherwise false</returns>
        public bool SetAbilities(string _ability1, string _ability2, string _ability3)
        {
            if (enumer.IsA_(PokeAbilityArr, _ability1.ToUpper()) && (enumer.IsA_(PokeAbilityArr, _ability2.ToUpper()) || _ability2 == "")
                && (enumer.IsA_(PokeAbilityArr, _ability3.ToUpper()) || _ability3 == "" ))
            {
                var poke_ability1 = enumer.ConvertTo_AsEnum(PokeAbilityArr, _ability1.ToUpper());
                var poke_ability2 = enumer.ConvertTo_AsEnum(PokeAbilityArr, _ability2.ToUpper());
                var poke_ability3 = enumer.ConvertTo_AsEnum(PokeAbilityArr, _ability3.ToUpper());

                if(poke_ability1 != PokeAbility.NULL)
                {
                    Ability1 = poke_ability1;
                    Ability2 = poke_ability2;
                    HiddenAbility = poke_ability3;
                }

                Abilities = new Tuple<PokeAbility?, PokeAbility?, PokeAbility?>(Ability1, Ability2, HiddenAbility);
                return true;
            }
            return false;
        }

        /// <summary>
        /// If _ability is a valid ability, then sets this.Abilities at _index to _ability and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="_ability"></param>
        /// <returns>True if the method successfully set this.Abilities at _index to _ability. otherwise false</returns>
        public bool SetAbility(int _index, string _ability)
        {
            if (enumer.IsA_(PokeAbilityArr, _ability.ToUpper()) || (_index > 0 && _ability == ""))
            {
                PokeAbility? poke_ability = enumer.ConvertTo_AsEnum(PokeAbilityArr, _ability.ToUpper());

                switch (_index)
                {
                    case 0: Ability1 = poke_ability; break;
                    case 1: Ability2 = poke_ability; break;
                    case 2: HiddenAbility = poke_ability; break;
                    default:
                        return false;
                }

                Abilities = new Tuple<PokeAbility?, PokeAbility?, PokeAbility?>(Ability1, Ability2, HiddenAbility);
                return true;
            }
            return false;
        }
        #endregion ABILITIES

        #region MOVES
        #region LEARNMOVES
        /// <summary>
        /// Return this.LearnMoves
        /// </summary>
        /// <returns>this.LearnMoves</returns>
        public string GetLearnMoves()
        {
            return LearnMoves;
        }

        /// <summary>
        /// If _moves is not null sets this.LearnMoves to _moves and returns true, otherwise returns false
        /// </summary>
        /// <param name="_moves"></param>
        /// <returns>True if the method successfully set this.LearnMoves to _value, otherwise false</returns>
        public bool SetLearnMoves(string _moves)
        {
            if(_moves != null && _moves != string.Empty)
            {
                LearnMoves = _moves;
                return true;
            }
            return false;
        }
        #endregion LEARNMOVES

        #region TUTORMOVES
        /// <summary>
        /// Return this.TutorMoves
        /// </summary>
        /// <returns>this.TutorMoves</returns>
        public string GetTutorMoves()
        {
            return TutorMoves;
        }

        /// <summary>
        /// If _moves is not null sets this.TutorMoves to _moves and returns true, otherwise returns false
        /// </summary>
        /// <param name="_moves"></param>
        /// <returns>True if the method successfully set this.TutorMoves to _value, otherwise false</returns>
        public bool SetTutorMoves(string _moves)
        {
            if (_moves != null && _moves != string.Empty)
            {
                TutorMoves = _moves;
                return true;
            }
            return false;
        }
        #endregion TUTORMOVES

        #region EGGMOVES
        /// <summary>
        /// Return this.EggMoves
        /// </summary>
        /// <returns>this.EggMoves</returns>
        public string GetEggMoves()
        {
            return EggMoves;
        }

        /// <summary>
        /// If _moves is not null sets this.EggMoves to _moves and returns true, otherwise returns false
        /// </summary>
        /// <param name="_moves"></param>
        /// <returns>True if the method successfully set this.EggMoves to _value, otherwise false</returns>
        public bool SetEggMoves(string _moves)
        {
            if (_moves != null)
            {
                EggMoves = _moves;
                return true;
            }
            return false;
        }
        #endregion EGGMOVES

        #region TM_MOVES
        /// <summary>
        /// Return this.TM_Moves
        /// </summary>
        /// <returns>this.TM_Moves</returns>
        public string GetTM_Moves()
        {
            return TM_Moves;
        }

        /// <summary>
        /// If _moves is not null sets this.TM_Moves to _moves and returns true, otherwise returns false
        /// </summary>
        /// <param name="_moves"></param>
        /// <returns>True if the method successfully set this.TM_Moves to _value, otherwise false</returns>
        public bool SetTM_Moves(string _moves)
        {
            if (_moves != null && _moves != string.Empty)
            {
                TM_Moves = _moves;
                return true;
            }
            return false;
        }
        #endregion TM_MOVES

        #region TR_MOVES
        /// <summary>
        /// Return this.TR_Moves
        /// </summary>
        /// <returns>this.TR_Moves</returns>
        public string GetTR_Moves()
        {
            return TR_Moves;
        }

        /// <summary>
        /// If _moves is not null sets this.TR_Moves to _moves and returns true, otherwise returns false
        /// </summary>
        /// <param name="_moves"></param>
        /// <returns>True if the method successfully set this.TR_Moves to _value, otherwise false</returns>
        public bool SetTR_Moves(string _moves)
        {
            if (_moves != null && _moves != string.Empty)
            {
                TR_Moves = _moves;
                return true;
            }
            return false;
        }
        #endregion TR_MOVES
        #endregion MOVES

        #region EGG_GROUPS
        /// <summary>
        /// Returns this.EggGroups
        /// </summary>
        /// <returns>this.EggGroups</returns>
        public Tuple<PokeEggGroup?, PokeEggGroup?> GetEggGroups()
        {
            return EggGroups;
        }

        /// <summary>
        /// Returns the type at _index from this.EggGroups
        /// if the _index is not set to 0 or 1 returns null
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <returns>The type at _index from this.EggGroups</returns>
        public string GetEggGroup(int _index)
        {
            switch (_index)
            {
                case 0: return EggGroups.Item1.ToString();
                case 1: return EggGroups.Item2.ToString();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns true if either of the this.EggGroups equals _group
        /// </summary>
        /// <param name="_group"></param>
        /// <returns>True if either of this.EggGroups equals the _group</returns>
        public bool HasEggGroup(string _group)
        {
            if (enumer.IsA_(PokeEggGroupArr, _group))
            {
                if (nameof(EggGroups.Item1) == _group || nameof(EggGroups.Item2) == _group)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If _group1 and _group2 are valid PokeEggGroups, then sets this.EggGroups to _group1 and _group2 and returns true.
        /// otherwise returns false
        /// </summary>
        /// <param name="_group1"></param>
        /// <param name="_group2"></param>
        /// <returns>True if the method successfully set this.EggGroups. otherwise false</returns>
        public bool SetEggGroups(string _group1, string _group2)
        {
            if (enumer.IsA_(PokeEggGroupArr, _group1.ToUpper()) && (enumer.IsA_(PokeEggGroupArr, _group2.ToUpper()) || _group2 == ""))
            {
                var poke_group1 = enumer.ConvertTo_AsEnum(PokeEggGroupArr, _group1.ToUpper());
                var poke_group2 = enumer.ConvertTo_AsEnum(PokeEggGroupArr, _group2.ToUpper());

                if (poke_group1 != PokeEggGroup.NULL)
                {
                    EggGroup1 = poke_group1;
                    EggGroup2 = poke_group2;

                    EggGroups = new Tuple<PokeEggGroup?, PokeEggGroup?>(EggGroup1, EggGroup2);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If _group is a valid PokeEggGroup sets the EggGroup at _index in this.EggGroups to _group and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <param name="_group"></param>
        /// <returns>True if the method successfully set this.EggGroups at _index to _group. otherwise false</returns>
        public bool SetEggGroup(int _index, string _group)
        {
            if (enumer.IsA_(PokeEggGroupArr, _group.ToUpper()) || (_index > 0 && _group == ""))
            {
                PokeEggGroup? poke_group = enumer.ConvertTo_AsEnum(PokeEggGroupArr, _group.ToUpper());

                switch (_index)
                {
                    case 0: EggGroup1 = poke_group; break;
                    case 1: EggGroup2 = poke_group; break;
                    default:
                        return false;
                }

                EggGroups = new Tuple<PokeEggGroup?, PokeEggGroup?>(EggGroup1, EggGroup2);
                return true;
            }
            return false;
        }
        #endregion EGG_GROUPS

        #region STEPS_TO_HATCH
        /// <summary>
        /// Returns this.StepsToHatch
        /// </summary>
        /// <returns>this.StepsToHatch </returns>
        public int? GetStepsToHatch()
        {
            return StepsToHatch;
        }

        /// <summary>
        /// If _num is greater than 0 sets this.StepsToHatch to _num and returns true, otherwise returns false
        /// </summary>
        /// <param name="_num"></param>
        /// <returns>True if the method successfully set this.StepsToHatch, otherwise false</returns>
        public bool SetStepsToHatch(int? _num)
        {
            if (_num > 0)
            {
                StepsToHatch = _num;
                return true;
            }
            return false;
        }
        #endregion STEPS_TO_HATCH

        #region HEIGHT
        /// <summary>
        /// Returns this.Height
        /// </summary>
        /// <returns>this.Height </returns>
        public double? GetHeight()
        {
            return Height;
        }

        /// <summary>
        /// If _num is greater than 0 sets this.Height to _num and returns true, otherwise returns false
        /// </summary>
        /// <param name="_num"></param>
        /// <returns>True if the method successfully set this.Height, otherwise false</returns>
        public bool SetHeight(double? _num)
        {
            if (_num > 0.0)
            {
                Height = _num;
                return true;
            }
            return false;
        }
        #endregion HEIGHT

        #region Weight
        /// <summary>
        /// Returns this.Weight
        /// </summary>
        /// <returns>this.Weight </returns>
        public double? GetWeight()
        {
            return Weight;
        }

        /// <summary>
        /// If _num is greater than 0 sets this.Weight to _num and returns true, otherwise returns false
        /// </summary>
        /// <param name="_num"></param>
        /// <returns>True if the method successfully set this.Weight, otherwise false</returns>
        public bool SetWeight(double? _num)
        {
            if (_num > 0.0)
            {
                Weight = _num;
                return true;
            }
            return false;
        }
        #endregion Weight

        #region COLOR
        /// <summary>
        /// Returns this.Color
        /// </summary>
        /// <returns>this.Color</returns>
        public PokeColor? GetColor()
        {
            return Color;
        }

        /// <summary>
        /// If _color is a valid PokeColor sets this.Color to _color and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_color"></param>
        /// <returns>True if the method successfully set this.Color to _color, otherwise false</returns>
        public bool SetColor(string _color)
        {
            if (enumer.IsA_(PokeColorArr, _color))
            {
                PokeColor? poke_color = enumer.ConvertTo_AsEnum(PokeColorArr, _color);

                Color = poke_color;
                return true;
            }
            return false;
        }
        #endregion COLOR

        #region SHAPE
        /// <summary>
        /// Returns this.Shape
        /// </summary>
        /// <returns>this.Shape</returns>
        public PokeShape? GetShape()
        {
            return Shape;
        }

        /// <summary>
        /// If _shape is a valid PokeShape sets this.Shape to _shape and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_shape"></param>
        /// <returns>True if the method successfully set this.Shape to _shape, otherwise false</returns>
        public bool SetShape(string _shape)
        {
            if (enumer.IsA_(PokeShapeArr, _shape))
            {
                PokeShape? poke_shape = enumer.ConvertTo_AsEnum(PokeShapeArr, _shape);

                Shape = poke_shape;
                return true;
            }
            return false;
        }
        #endregion SHAPE

        #region KIND
        /// <summary>
        /// Returns this.Kind
        /// </summary>
        /// <returns> the string, this.Kind </returns>
        public string GetKind()
        {
            return Kind;
        }

        /// <summary>
        /// If _kind is a valid Name, sets this.Kind to _kind and returns true, otherwise returns false
        /// </summary>
        /// <param name="_kind"></param>
        /// <returns>True if the method successfully set this.Kind, otherwise false</returns>
        public bool SetKind(string _kind)
        {
            if (IsValidName(_kind))
            {
                Kind = _kind;
                return true;
            }
            return false;
        }
        #endregion KIND

        #region DEX_ENTRY
        /// <summary>
        /// Returns this.DexEntry
        /// </summary>
        /// <returns>this.DexEntry </returns>
        public string GetDexEntry()
        {
            return DexEntry;
        }

        /// <summary>
        /// If _entry.Length is greater than 0 but less than 161 characters, sets this.DexEntry to _entry
        /// and returns true, otherwise returns false
        /// </summary>
        /// <param name="_entry"></param>
        /// <returns>True if the method successfully set this.DexEntry, otherwise false</returns>
        public bool SetDexEntry(string _entry)
        {
            if (_entry.Length > 0 && _entry.Length <= 165)
            {
                DexEntry = _entry;
                return true;
            }
            return false;
        }
        #endregion DEX_ENTRY

        #region GEN
        /// <summary>
        /// Returns this.Generation
        /// </summary>
        /// <returns>this.Generation</returns>
        public int? GetGeneration()
        {
            return Generation;
        }

        /// <summary>
        /// If _num is between 0 and less than NUM_GENS, sets this.Generation to _num and returns true, otherwise returns false
        /// </summary>
        /// <param name="_num"></param>
        /// <returns>True if the method successfully set this.Generation, otherwise false</returns>
        public bool SetGeneration(int? _num)
        {
            if (_num > 0 && _num <= NUM_GENS)
            {
                Generation = _num;
                return true;
            }
            return false;
        }
        #endregion GEN

        #region WILD_ITEMS
        /// <summary>
        /// Returns this.WildItems
        /// </summary>
        /// <returns>this.WildItems</returns>
        public Tuple<string, string, string> GetWildItems()
        {
            return WildItems;
        }

        /// <summary>
        /// Returns the ability at _index from this.WildItems
        /// if the _index is not set to 0:2 returns null
        /// </summary>
        /// <param name="_index">0-based, 0 = Common, 1 = Uncommon, 2 = Rare</param>
        /// <returns>The ability at _index from this.WildItems</returns>
        public string GetWildItem(int _index)
        {
            switch (_index)
            {
                case 0: return WildItems.Item1.ToString();  // Common
                case 1: return WildItems.Item2.ToString();  // Uncommon
                case 2: return WildItems.Item3.ToString();  // Rare
                default:
                    return null;
            }
        }

        /// <summary>
        /// If _item1 is not null, then sets this.WildItems to
        /// _item1, _item2, and _item3 and returns true. otherwise returns false
        /// </summary>
        /// <param name="_item1">Common</param>
        /// <param name="_item2">Uncommon</param>
        /// <param name="_item3">Rare</param>
        /// <returns>True if the method successfully set this.WildItems at _index to _item. otherwise false</returns>
        public bool SetWildItems(string _item1, string? _item2, string? _item3)
        {
            if (_item1 != null && _item1 != string.Empty)
            {
                WildItem1 = _item1.ToUpper();
                if(_item2 != null)
                    WildItem2 = _item2.ToUpper();
                else
                    WildItem2 = string.Empty;
                if (_item3 != null)
                    WildItem3 = _item3.ToUpper();
                else
                    WildItem3 = string.Empty;

                WildItems = new Tuple<string, string, string>(WildItem1, WildItem2, WildItem3);
                return true;
            }
            return false;
        }

        /// <summary>
        /// If _item is a valid ability, then sets this.WildItems at _index to _item and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="_item"></param>
        /// <returns>True if the method successfully set this.WildItems at _index to _item. otherwise false</returns>
        public bool SetWildItem(int _index, string _item)
        {
            if (_item != null && _item != string.Empty)
            {

                switch (_index)
                {
                    case 0: WildItem1 = _item; break;   // Common
                    case 1: WildItem2 = _item; break;   // Uncommon
                    case 2: WildItem3 = _item; break;   // Rare
                    default:
                        return false;
                }

                WildItems = new Tuple<string, string, string>(WildItem1, WildItem2, WildItem3);
                return true;
            }
            return false;
        }
        #endregion WILD_ITEMS

        #region FORMS
        /// <summary>
        /// Returns this.HasForms
        /// </summary>
        /// <returns>this.HasForms</returns>
        public bool HasMultipleForms()
        {
            return (bool)HasForms;
        }

        /// <summary>
        /// sets this.HasForms equal to  _hasforms and returns true.
        /// If _formname is not a valid name returns false
        /// </summary>
        /// <param name="_hasforms"></param>
        /// <param name="_formname" default = null></param>
        /// <returns>True if the method successfully set this.HasForms, otherwise false</returns>
        public bool SetHasMultipleForms(bool _hasforms, string _formname = null)
        {
            HasForms = _hasforms;

            if (_formname != null)
            {
                if (!SetFormName(_formname))
                {
                    return false;   // failed to SetFormName with _formname
                }
            }

            if (HasForms != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns this.FormNames
        /// </summary>
        /// <returns>this.FormNames</returns>
        public List<string> GetFormNames()
        {
            return FormNames;
        }

        /// <summary>
        /// Returns the form name at _index
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <returns>The form name at _index</returns>
        public string GetFormName(int _index)
        {
            return FormNames[_index];
        }

        /// <summary>
        /// If _formname is a valid name, adds it to this.FormNames and returns true.
        /// If this.HasForms is not true or if the _formname is an invalid name returns false
        /// </summary>
        /// <param name="_hasforms"></param>
        /// <returns>True if the method successfully adds to this.FormNames, otherwise false</returns>
        public bool SetFormName(string _formname)
        {
            if (HasForms == true && IsValidName(_formname))
            {
                if (FormNames == null)
                {
                    FormNames = new List<string>();
                }
                FormNames.Add(_formname);
                FormNames.Sort();
                return true;
            }

            return false;
        }

        /// <summary>
        /// If all of _formnames are valid names, sets this.FormNames with _formnames and returns true.
        /// If this.HasForms is not true or if any of _formnames are invalid names returns false
        /// </summary>
        /// <param name="_hasforms"></param>
        /// <returns>True if the method successfully set this.FormNames, otherwise false</returns>
        public bool SetFormNames(List<string> _formnames)
        {
            bool allValid = false;
            foreach (string _formname in _formnames)
            {
                allValid = IsValidName(_formname);
            }
            if (HasForms == true && allValid)
            {
                if (FormNames == null)
                {
                    FormNames = new List<string>();
                }
                FormNames = _formnames;
                return true;
            }

            return false;
        }
        #endregion FORMS

        #region POSITIONING
        public int? GetBattlerPlayerX()
        {
            return BattlerPlayerX;
        }

        public void SetBattlerPlayerX(int _value)
        {
            BattlerPlayerX = _value;
        }

        public int? GetBattlerPlayerY()
        {
            return BattlerPlayerY;
        }

        public void SetBattlerPlayerY(int _value)
        {
            BattlerPlayerY = _value;
        }

        public int? GetBattlerEnemyX()
        {
            return BattlerEnemyX;
        }

        public void SetBattlerEnemyX(int _value)
        {
            BattlerEnemyX = _value;
        }

        public int? GetBattlerEnemyY()
        {
            return BattlerEnemyY;
        }

        public void SetBattlerEnemyY(int _value)
        {
            BattlerEnemyY = _value;
        }

        public int? GetBattlerShadowX()
        {
            return BattlerShadowX;
        }

        public void SetBattlerShadowX(int _value)
        {
            BattlerShadowX = _value;
        }

        public int? GetBattlerShadowSize()
        {
            return BattlerShadowSize;
        }

        public void SetBattlerShadowSize(int _value)
        {
            BattlerShadowSize = _value;
        }

        #endregion POSITIONING

        #region EVOLUTIONS
        /// <summary>
        /// Returns this.Evolutions
        /// </summary>
        /// <returns>this.Evolutions </returns>
        public string GetEvolutions()
        {
            return Evolutions;
        }

        /// <summary>
        /// If _evos is not null sets this.Evolutions to _evos and returns true, otherwise returns false
        /// </summary>
        /// <param name="_evos"></param>
        /// <returns>True if the method successfully set this.Evolutions, otherwise false</returns>
        public bool SetEvolutions(string _evos)
        {
            if (_evos != null || _evos == "")
            {
                Evolutions = _evos;
                return true;
            }
            return false;
        }
        #endregion EVOLUTIONS

        #region EXTRAS
        #region ALTERED
        /// <summary>
        /// Returns this.Altered
        /// </summary>
        /// <returns>this.Altered</returns>
        public bool? IsAltered()
        {
            return Altered;
        }

        /// <summary>
        /// Set this.Altered to _altered
        /// </summary>
        /// <param name="_altered"></param>
        public void SetAltered(bool _altered)
        {
            Altered = _altered;
        }
        #endregion ALTERED

        #region STARTER
        /// <summary>
        /// Returns this.Starter
        /// </summary>
        /// <returns>this.Starter</returns>
        public bool? IsStarter()
        {
            return Starter;
        }

        /// <summary>
        /// Set this.Starter to _starter
        /// </summary>
        /// <param name="_starter"></param>
        public void SetStarter(bool _starter)
        {
            Starter = _starter;
        }
        #endregion STARTER

        #region GUARDIAN
        /// <summary>
        /// Returns this.Guardian
        /// </summary>
        /// <returns>this.Guardian</returns>
        public bool? IsGuardian()
        {
            return Guardian;
        }

        /// <summary>
        /// Set this.Guardian to _guardian
        /// </summary>
        /// <param name="_guardian"></param>
        public void SetGuardian(bool _guardian)
        {
            Guardian = _guardian;
        }
        #endregion GUARDIAN

        #region POSTGAME
        /// <summary>
        /// Returns this.PostGame
        /// </summary>
        /// <returns>this.PostGame</returns>
        public bool? IsPostGame()
        {
            return PostGame;
        }

        /// <summary>
        /// Set this.PostGame to _postgame
        /// </summary>
        /// <param name="_postgame"></param>
        public void SetPostGame(bool _postgame)
        {
            PostGame = _postgame;
        }
        #endregion POSTGAME
        #endregion EXTRAS
    }
}
