using System;
using System.Collections.Generic;
using System.Runtime;

namespace PokeSpreadsheetsToTxt
{
    public class Move
    {
        // 1,MEGAHORN,Megahorn,000,120,BUG,Physical,85,10,0,NearOther,0,abef,""

        private string Name, InternalName;
        private int? MoveNumber;
        private string Code;
        private int? BasePower;
        private static PokeType? Type1, Type2;
        private Tuple<PokeType?, PokeType?> Types = new Tuple<PokeType?, PokeType?>(Type1, Type2);
        private MoveCategory? Category;
        private int? Accuracy, PowerPoints, EffectChance;
        private MoveTarget? Target;
        private int? Priority;
        private static bool? DirectContact_a, Defendable_b, Redirectable_c, Snatchable_d, Copyable_e, AidFlinch_f, Thawing_g,
            HighCritChance_h, Biting_i, Punching_j, Sound_k, Powder_l, Pulse_m, BallBomb_n, Dance_o, Song_p, Gravity_q;
        private List<bool?> Flags = new List<bool?>() { DirectContact_a, Defendable_b, Redirectable_c, Snatchable_d, Copyable_e, AidFlinch_f, Thawing_g,
            HighCritChance_h, Biting_i, Punching_j, Sound_k, Powder_l, Pulse_m, BallBomb_n, Dance_o, Song_p, Gravity_q };
        private string Flags_STR;
        private string Description;

        // The following have no accessors
        private EnumMethods enumer = new EnumMethods();

        private static List<PokeType> PokeTypeArr = new List<PokeType> { PokeType.NULL, PokeType.NORMAL, PokeType.FIGHTING,
            PokeType.FLYING, PokeType.POISON, PokeType.GROUND, PokeType.ROCK, PokeType.BUG, PokeType.GHOST, PokeType.STEEL,
            PokeType.FIRE, PokeType.WATER, PokeType.GRASS, PokeType.ELECTRIC, PokeType.PSYCHIC, PokeType.ICE, PokeType.DRAGON,
            PokeType.DARK, PokeType.FAIRY, PokeType.STAR, PokeType.SOUND };

        private static List<MoveCategory> MoveCategoryArr = new List<MoveCategory>() { MoveCategory.NULL, MoveCategory.PHYSICAL,
            MoveCategory.SPECIAL, MoveCategory.STATUS };

        private static List<MoveTarget> MoveTargetArr = new List<MoveTarget>() { MoveTarget.Null, MoveTarget.None, MoveTarget.User,
            MoveTarget.NearAlly, MoveTarget.UserOrNearAlly, MoveTarget.UserAndAllies, MoveTarget.NearFoe, MoveTarget.AllNearFoes,
            MoveTarget.RandomNearFoe, MoveTarget.Foe, MoveTarget.AllFoes, MoveTarget.NearOther, MoveTarget.AllNearOthers, MoveTarget.Other,
            MoveTarget.AllBattlers, MoveTarget.UserSide, MoveTarget.FoeSide, MoveTarget.BothSides};


        /// <summary>
        /// Constructor, sets all values to null to start.
        /// </summary>
        public Move()
        {
            Name = null; InternalName = null; MoveNumber = null; Code = null; BasePower = null;
            Type1 = null; Type2 = null; Types = new Tuple<PokeType?, PokeType?>(Type1, Type2);
            Category = null; Accuracy = null; PowerPoints = null; EffectChance = null;
            Target = null; Priority = null; 
            DirectContact_a = null; Defendable_b = null; Redirectable_c = null; Snatchable_d = null; Copyable_e = null; AidFlinch_f = null; Thawing_g = null;
            HighCritChance_h = null; Biting_i = null; Punching_j = null; Sound_k = null; Powder_l = null; Pulse_m = null; BallBomb_n = null; Dance_o = null; Song_p = null; Gravity_q = null;
            Flags = new List<bool?>() { DirectContact_a, Defendable_b, Redirectable_c, Snatchable_d, Copyable_e, AidFlinch_f, Thawing_g,
                HighCritChance_h, Biting_i, Punching_j, Sound_k, Powder_l, Pulse_m, BallBomb_n, Dance_o, Song_p, Gravity_q };
            Flags_STR = null;
            Description = null;
        }

        #region NAMES
        /// <summary>
        /// Returns this.Name
        /// </summary>
        /// <returns>this.Name</returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// If _name is not null, sets this.Name to _name and returns true, otherwise returns false
        /// </summary>
        /// <param name="_name"></param>
        /// <returns>True if the method successfully set this.Name, otherwise returns false</returns>
        public bool SetName(string _name)
        {
            if (_name != null)
            {
                Name = _name;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetInternalName()
        {
            return InternalName;
        }

        /// <summary>
        /// If _internalname is not null, sets this.InternalName to _internalname and returns true, otherwise returns false
        /// </summary>
        /// <param name="_internalname"></param>
        /// <returns>True if the method successfully set this.InternalName, otherwise false</returns>
        public bool SetInternalName(string _internalname)
        {
            if (_internalname != null)
            {
                InternalName = _internalname;
                return true;
            }
            return false;
        }
        #endregion NAMES

        #region MOVENUMBER
        /// <summary>
        /// Returns the value of this.MoveNumber
        /// </summary>
        /// <returns> the int?, this.MoveNumber </returns>
        public int? GetMoveNumber()
        {
            return MoveNumber;
        }

        /// <summary>
        /// If _num is greater than 0 sets this.MoveNumber to _num and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_num"></param>
        /// <returns>True if the method successfully set this.MoveNumber, otherwise false</returns>
        public bool SetMoveNumber(int? _num)
        {
            if (_num > 0)
            {
                MoveNumber = _num;
                return true;
            }
            return false;
        }
        #endregion MOVENUMBER

        #region CODE
        /// <summary>
        /// Returns this.Code
        /// </summary>
        /// <returns>this.Code</returns>
        public string GetCode()
        {
            return Code;
        }

        /// <summary>
        /// If _code length is 3 chracters, sets this.Code to _code and returns true, otherwise returns false
        /// </summary>
        /// <param name="_code"></param>
        /// <returns>True if the method successfully set this.Code, otherwise returns false</returns>
        public bool SetCode(string _code)
        {
            if (_code.Length == 3)
            {
                Code = _code;
                return true;
            }
            return false;
        }
        #endregion CODE

        #region POWER
        /// <summary>
        /// Returns the value of this.BasePower
        /// </summary>
        /// <returns> the int?, this.BasePower </returns>
        public int? GetBasePower()
        {
            return BasePower;
        }

        /// <summary>
        /// If _value is greater than or equal to 0 sets this.BasePower to _value and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.BasePower, otherwise returns false</returns>
        public bool SetBasePower(int? _value)
        {
            if (_value >= 0)
            {
                BasePower = _value;
                return true;
            }
            return false;
        }
        #endregion POWER

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
            if (enumer.IsA_(PokeTypeArr, _type1) && enumer.IsA_(PokeTypeArr, _type2))
            {
                Type1 = enumer.ConvertTo_AsEnum(PokeTypeArr, _type1);
                Type2 = enumer.ConvertTo_AsEnum(PokeTypeArr, _type2);

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
            if (enumer.IsA_(PokeTypeArr, _type))
            {
                PokeType? poke_type = enumer.ConvertTo_AsEnum(PokeTypeArr, _type);

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

        #region CATEGORY
        /// <summary>
        /// Returns this.Category
        /// </summary>
        /// <returns>this.Category</returns>
        public MoveCategory? GetCategory()
        {
            return Category;
        }

        /// <summary>
        /// If _cat is a valid MoveCategory sets this.Category to _cat and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_cat"></param>
        /// <returns>True if the method successfully set this.Category to _cat, otherwise false</returns>
        public bool SetCategory(string _cat)
        {
            if (enumer.IsA_(MoveCategoryArr, _cat))
            {
                MoveCategory? move_cat = enumer.ConvertTo_AsEnum(MoveCategoryArr, _cat);

                Category = move_cat;
                return true;
            }
            return false;
        }
        #endregion CATEGORY

        #region TARGET
        /// <summary>
        /// Returns this.Target
        /// </summary>
        /// <returns>this.Target</returns>
        public MoveTarget? GetTarget()
        {
            return Target;
        }

        /// <summary>
        /// If _target is a valid MoveTarget sets this.Target to _target and returns true
        /// otherwise returns false
        /// </summary>
        /// <param name="_target"></param>
        /// <returns>True if the method successfully set this.Target to _target, otherwise false</returns>
        public bool SetTarget(string _target)
        {
            if (enumer.IsA_(MoveTargetArr, _target))
            {
                MoveTarget? move_target = enumer.ConvertTo_AsEnum(MoveTargetArr, _target);

                Target = move_target;
                return true;
            }
            return false;
        }
        #endregion TARGET

        #region ACCURACY
        /// <summary>
        /// Returns the value of this.Accuracy
        /// </summary>
        /// <returns> the int?, this.Accuracy </returns>
        public int? GetAccuracy()
        {
            return Accuracy;
        }

        /// <summary>
        /// If _value is between 0 and 100 inclusive, sets this.Accuracy to _value and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.Accuracy, returns false</returns>
        public bool SetAccuracy(int? _value)
        {
            if (_value >= 0 && _value <= 100)
            {
                Accuracy = _value;
                return true;
            }
            return false;
        }
        #endregion ACCURACY

        #region PP
        /// <summary>
        /// Returns the value of this.PowerPoints
        /// </summary>
        /// <returns> the int?, this.PowerPoints </returns>
        public int? GetPowerPoints()
        {
            return PowerPoints;
        }

        /// <summary>
        /// If _value is greater than 0 sets this.PowerPoints to _value and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.PowerPoints, otherwise false</returns>
        public bool SetPowerPoints(int? _value)
        {
            if (_value > 0)
            {
                PowerPoints = _value;
                return true;
            }
            return false;
        }
        #endregion PP

        #region CHANCE   
        /// <summary>
        /// Returns the value of this.EffectChance
        /// </summary>
        /// <returns> the int?, this.EffectChance </returns>
        public int? GetEffectChance()
        {
            return EffectChance;
        }

        /// <summary>
        /// If _value is between 0 and 100 inclusive, sets this.EffectChance to _value and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.EffectChance, returns false</returns>
        public bool SetEffectChance(int? _value)
        {
            if (_value >= 0 && _value <= 100)
            {
                EffectChance = _value;
                return true;
            }
            return false;
        }
        #endregion CHANCE

        #region Priority
        /// <summary>
        /// Returns the value of this.Priority
        /// </summary>
        /// <returns> the int?, this.Priority </returns>
        public int? GetPriority()
        {
            return Priority;
        }

        /// <summary>
        /// If _value is between -6 and 7 inclusive, sets this.Priority to _value and returns true.
        /// false otherwise
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>True if the method successfully set this.Priority, returns false</returns>
        public bool SetPriority(int? _value)
        {
            if (_value >= -6 && _value <= 7)
            {
                Priority = _value;
                return true;
            }
            return false;
        }
        #endregion Priority

        #region FLAGS
        /// <summary>
        /// Returns this.Flags
        /// </summary>
        /// <returns>this.Flags</returns>
        public List<bool?> GetFlags()
        {
            return Flags;
        }

        /// <summary>
        /// Returns this.Flags_STR (the string version of List<bool?> of this.Flags
        /// </summary>
        /// <returns>this.Flags_STR</returns>
        public string GetFlags_STR()
        {
            return Flags_STR;
        }

        /// <summary>
        /// Returns the flag at _index in this.Flags
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <returns>flag at _index in this.Flags</returns>
        public bool? GetFlag(int _index)
        {
            return Flags[_index];
        }

        /// <summary>
        /// If any of the flags are not null sets this.Flags and returns true, otherwise returns falsegrav_q
        /// </summary>
        /// <param name="_contact_a"></param> <param name="_defend_b"></param> <param name="_redirect_c"></param> <param name="_snatch_d"></param>
        /// <param name="_copy_e"></param> <param name="_flinch_f"></param> <param name="_thaw_g"></param> <param name="_crit_h"></param>
        /// <param name="_bite_i"></param> <param name="_punch_j"></param> <param name="_sound_k"></param> <param name="_powder_l"></param>
        /// <param name="_pulse_m"></param> <param name="_bomb_n"></param> <param name="_dance_o"></param> <param name="_song_p"></param>
        /// <param name="_grav_q"></param>
        /// <returns>True if the method successfully set this.Flags, returns false</returns>
        public bool SetFlags(bool? _contact_a, bool? _defend_b, bool? _redirect_c, bool? _snatch_d, bool? _copy_e, bool? _flinch_f, bool? _thaw_g,
            bool? _crit_h, bool? _bite_i, bool? _punch_j, bool? _sound_k, bool? _powder_l, bool? _pulse_m, bool? _bomb_n, bool? _dance_o, bool? _song_p, bool? _grav_q)
        {
            if (_contact_a != null || _defend_b != null || _redirect_c != null || _snatch_d != null || _copy_e != null
                || _flinch_f != null || _thaw_g != null || _crit_h != null || _bite_i != null || _punch_j != null || _sound_k != null
                || _powder_l != null || _pulse_m != null || _bomb_n != null || _dance_o != null || _song_p != null || _grav_q != null)
            {
                DirectContact_a = _contact_a;
                Defendable_b = _defend_b;
                Redirectable_c = _redirect_c;
                Snatchable_d = _snatch_d;
                Copyable_e = _copy_e;
                AidFlinch_f = _flinch_f;
                Thawing_g = _thaw_g;
                HighCritChance_h = _crit_h;
                Biting_i = _bite_i;
                Punching_j = _punch_j;
                Sound_k = _sound_k;
                Powder_l = _powder_l;
                Pulse_m = _pulse_m;
                BallBomb_n = _bomb_n;
                Dance_o = _dance_o;
                Song_p = _song_p;
                Gravity_q = _grav_q;

                Flags = new List<bool?>() { DirectContact_a, Defendable_b, Redirectable_c, Snatchable_d, Copyable_e, AidFlinch_f, Thawing_g,
                            HighCritChance_h, Biting_i, Punching_j, Sound_k, Powder_l, Pulse_m, BallBomb_n, Dance_o, Song_p, Gravity_q };

                char flag = 'a';
                for (int i = 0; i < Flags.Count; i++)
                {
                    if (Flags[i] == true)
                    {
                        Flags_STR.Insert(i, $"{(char)(flag + i)}");
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// If _flags is not null, sets this.Flags and returns true, otherwise returns false
        /// </summary>
        /// <param name="_flags"> should be a string of characters with no spaces ex: "abef"</param>
        /// <returns>True if the method successfully set this.Flags, returns false</returns>
        public bool SetFlags(string _flags)
        {
            if (_flags != null)
            {
                for (int i = 0; i < _flags.Length; i++)
                {
                    switch (_flags[i])
                    {
                        case 'a':
                            DirectContact_a = true;
                            break;
                        case 'b':
                            Defendable_b = true;
                            break;
                        case 'c':
                            Redirectable_c = true;
                            break;
                        case 'd':
                            Snatchable_d = true;
                            break;
                        case 'e':
                            Copyable_e = true;
                            break;
                        case 'f':
                            AidFlinch_f = true;
                            break;
                        case 'g':
                            Thawing_g = true;
                            break;
                        case 'h':
                            HighCritChance_h = true;
                            break;
                        case 'i':
                            Biting_i = true;
                            break;
                        case 'j':
                            Punching_j = true;
                            break;
                        case 'k':
                            Sound_k = true;
                            break;
                        case 'l':
                            Powder_l = true;
                            break;
                        case 'm':
                            Pulse_m = true;
                            break;
                        case 'n':
                            BallBomb_n = true;
                            break;
                        case 'o':
                            Dance_o = true;
                            break;
                        case 'p':
                            Song_p = true;
                            break;
                        case 'q':
                            Gravity_q = true;
                            break;
                        default:
                            return false;
                    }
                }

                Flags = new List<bool?>() { DirectContact_a, Defendable_b, Redirectable_c, Snatchable_d, Copyable_e, AidFlinch_f, Thawing_g,
                    HighCritChance_h, Biting_i, Punching_j, Sound_k, Powder_l, Pulse_m, BallBomb_n, Dance_o, Song_p, Gravity_q };
                return true;
            }
            return false;
        }

        /// <summary>
        /// If _flag is greater than 0 sets the flag at _index in this.Flags 
        /// Then Flags_STR is updated and returns true
        /// </summary>
        /// <param name="_index">0-based</param>
        /// <param name="_flag"></param>
        /// <returns>True if the method successfully set this.Flags at _index to _flag. otherwise false</returns>
        public bool SetFlag(int _index, bool _flag)
        {
            switch (_index)
            {
                case 0: DirectContact_a = _flag; break;
                case 1: Defendable_b = _flag; break;
                case 2: Redirectable_c = _flag; break;
                case 3: Snatchable_d = _flag; break;
                case 4: Copyable_e = _flag; break;
                case 5: AidFlinch_f = _flag; break;
                case 6: Defendable_b = _flag; break;
                case 7: Redirectable_c = _flag; break;
                case 8: Snatchable_d = _flag; break;
                case 9: Copyable_e = _flag; break;
                case 10: AidFlinch_f = _flag; break;
                case 11: Thawing_g = _flag; break;
                case 12: HighCritChance_h = _flag; break;
                case 13: Biting_i = _flag; break;
                case 14: Punching_j = _flag; break;
                case 15: Sound_k = _flag; break;
                case 16: Powder_l = _flag; break;
                case 17: Pulse_m = _flag; break;
                case 18: BallBomb_n = _flag; break;
                case 19: Dance_o = _flag; break;
                case 20: Song_p = _flag; break;
                case 21: Gravity_q = _flag; break;
                default:
                    return false;
            }

            // Update Flags_STR
            char flag = 'a';
            for (int i = 0; i < Flags.Count; i++)
            {
                if (Flags[i] == true)
                {
                    Flags_STR.Insert(i, $"{(char)(flag + i)}");
                }
            }

            // Update Flags
            Flags = new List<bool?>() { DirectContact_a, Defendable_b, Redirectable_c, Snatchable_d, Copyable_e, AidFlinch_f, Thawing_g,
                HighCritChance_h, Biting_i, Punching_j, Sound_k, Powder_l, Pulse_m, BallBomb_n, Dance_o, Song_p, Gravity_q };
            return true;
        }
        #endregion FLAGS

        #region DESCRIPTION
        /// <summary>
        /// Returns this.Description
        /// </summary>
        /// <returns>this.Description</returns>
        public string GetDescription()
        {
            return Description;
        }

        /// <summary>
        /// If _text is not null, sets this.Description to _text and returns true, otherwise returns false
        /// </summary>
        /// <param name="_text"></param>
        /// <returns>True if the method successfully set this.Description, otherwise false</returns>
        public bool SetDescription(string _text)
        {
            if (_text != null)
            {
                Description = _text;
                return true;
            }
            return false;
        }
        #endregion DESCRIPTION
    }
}